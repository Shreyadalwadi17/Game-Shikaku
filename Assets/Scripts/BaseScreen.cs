using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ScreenType
{
   Home,
   Gameplay

}
public class BaseScreen : MonoBehaviour
{
    
    public ScreenType screenType;
    public Canvas canvas;


    public void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    public void OnPlayBtn()
    {
        ScreenManager.inst.SwitchScreen(ScreenType.Gameplay);
    }
}
