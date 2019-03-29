using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//events source
//https://www.youtube.com/watch?v=qwQ16sS8FSs


public class InputManager : MonoBehaviour
{
    public delegate void OnPurplePressed();
    public delegate void OnOrangePressed();
    public delegate void OnCyanPressed();
    public delegate void OnGreenPressed();
    public delegate void OnYellowPressed();
    public delegate void OnRedPressed();
    public delegate void OnPinkPressed();

    public static event OnPurplePressed onPurplePressed;
    public static event OnOrangePressed onOrangePressed;
    public static event OnCyanPressed onCyanPressed;
    public static event OnGreenPressed onGreenPressed;
    public static event OnYellowPressed onYellowPressed;
    public static event OnRedPressed onRedPressed;
    public static event OnPinkPressed onPinkPressed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (onPurplePressed != null)
                onPurplePressed();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (onOrangePressed != null)
                onOrangePressed();
        }
            
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (onCyanPressed != null)
                onCyanPressed();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (onGreenPressed != null)
                onGreenPressed();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (onYellowPressed != null)
                onYellowPressed();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            if (onRedPressed != null)
                onRedPressed();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onPinkPressed != null)
                onPinkPressed();
        }

    }
}
