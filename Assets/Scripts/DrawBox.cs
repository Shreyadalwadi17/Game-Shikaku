using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBox : MonoBehaviour
{
    public GameObject rectanglePrefab;
    private Camera mainCamera;

    private Vector2 startPoint;
    private Vector2 endPoint;
    private bool isDrawing = false;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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

    void StartDrawingRectangle()
    {
        startPoint = GetMouseWorldPosition();
        isDrawing = true;
    }

    void UpdateRectangle()
    {
        endPoint = GetMouseWorldPosition();
    }

    void StopDrawingRectangle()
    {
        isDrawing = false;

        // Calculate the size of the rectangle
        Vector2 size = endPoint - startPoint;

        // Create a new GameObject with a LineRenderer component
        GameObject newRectangle = Instantiate(rectanglePrefab, startPoint + size / 2f, Quaternion.identity);
        LineRenderer lineRenderer = newRectangle.GetComponent<LineRenderer>();

        // Set LineRenderer positions
        lineRenderer.positionCount = 5;
        lineRenderer.SetPositions(GetRectangleVertices(startPoint, endPoint));

        // Optionally, set other properties of the LineRenderer, such as color, width, etc.

        // You can also perform additional logic with the new rectangle GameObject if needed.
    }

    Vector2 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -mainCamera.transform.position.z;
        return mainCamera.ScreenToWorldPoint(mousePosition);
    }

    Vector3[] GetRectangleVertices(Vector2 start, Vector2 end)
    {
        // Calculate the vertices of the rectangle
        Vector3[] vertices = new Vector3[5];
        vertices[0] = start;
        vertices[1] = new Vector2(start.x, end.y);
        vertices[2] = end;
        vertices[3] = new Vector2(end.x, start.y);
        vertices[4] = start;

        return vertices;
    }
}