using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBox : MonoBehaviour
{
    public LineRenderer lineRendererPrefab;
    public Camera mainCamera;

    private Vector2 startPoint;
    private Vector2 endPoint;
    private bool isDrawing = false;
    private List<LineRenderer> drawnRectangles = new List<LineRenderer>();

    void Start()
    {
        if (lineRendererPrefab != null)
        {
            // Set up LineRendererPrefab
            lineRendererPrefab = new GameObject("LineRendererPrefab").AddComponent<LineRenderer>();
            lineRendererPrefab.material = new Material(Shader.Find("Sprites/Default"));
            lineRendererPrefab.startWidth = 0.1f;
            lineRendererPrefab.endWidth = 0.1f;
            lineRendererPrefab.material.color = Color.black;
        }

        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsMouseOverValidArea())
        {
            StartDrawingRectangle();
        }

        if (isDrawing)
        {
            UpdateRectangle();
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopDrawingRectangle();
        }
    }

    bool IsMouseOverValidArea()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            bool isOverValidArea = hit.collider.CompareTag("square");
            return isOverValidArea;
        }

        return false;
    }

    void StartDrawingRectangle()
    {
        startPoint = GetMouseWorldPosition();
        endPoint = startPoint;
        isDrawing = true;

        lineRendererPrefab.positionCount = 5;
        lineRendererPrefab.SetPositions(GetRectangleVertices());
    }

    void UpdateRectangle()
    {
        endPoint = GetMouseWorldPosition();
        lineRendererPrefab.SetPositions(GetRectangleVertices());
    }

    void StopDrawingRectangle()
    {
        isDrawing = false;

        // Check if the new rectangle overlaps with existing ones
        if (!IsOverlappingExistingRectangles())
        {
            LineRenderer newRectangle = Instantiate(lineRendererPrefab);
            newRectangle.positionCount = 5;
            newRectangle.SetPositions(GetRectangleVertices());
            drawnRectangles.Add(newRectangle);
        }
    }

    bool IsOverlappingExistingRectangles()
    {
        Rect newRect = new Rect(Mathf.Min(startPoint.x, endPoint.x),
                                Mathf.Min(startPoint.y, endPoint.y),
                                Mathf.Abs(endPoint.x - startPoint.x),
                                Mathf.Abs(endPoint.y - startPoint.y));

        foreach (LineRenderer existingRectangle in drawnRectangles)
        {
            Rect existingRect = GetRectFromLineRenderer(existingRectangle);

            if (existingRect.Overlaps(newRect))
            {
                
                return true;
            }
        }

        return false;
    }

    Rect GetRectFromLineRenderer(LineRenderer renderer)
    {
        Vector3[] positions = new Vector3[renderer.positionCount];
        renderer.GetPositions(positions);

        float minX = Mathf.Min(positions[0].x, positions[2].x);
        float minY = Mathf.Min(positions[0].y, positions[2].y);
        float width = Mathf.Abs(positions[2].x - positions[0].x);
        float height = Mathf.Abs(positions[2].y - positions[0].y);

        return new Rect(minX, minY, width, height);
    }

    Vector2 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -mainCamera.transform.position.z;
        return mainCamera.ScreenToWorldPoint(mousePosition);
    }

    Vector3[] GetRectangleVertices()
    {
        Vector3[] vertices = new Vector3[5];
        vertices[0] = startPoint;
        vertices[1] = new Vector2(startPoint.x, endPoint.y);
        vertices[2] = endPoint;
        vertices[3] = new Vector2(endPoint.x, startPoint.y);
        vertices[4] = startPoint;

        return vertices;
    }
}