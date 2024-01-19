using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public BaseScreen[] screen;
    public BaseScreen CurrentScreen;
    public static ScreenManager inst;


    private void Awake()
    {
        inst = this;
        CurrentScreen.canvas.enabled = true;

    }

    public void SwitchScreen(ScreenType screenType)
    {
        //Debug.Log("screen");
        CurrentScreen.canvas.enabled = false;
        foreach (BaseScreen baseScreen in screen)
        {
            if (baseScreen.screenType == screenType)
            {
                baseScreen.canvas.enabled = true;
                CurrentScreen = baseScreen;
                break;
            }
        }
    }
}
