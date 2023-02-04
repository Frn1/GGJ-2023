using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    private void Start()
    {
        #if UNITY_WEBGL
            Destroy(this);
        #endif
    }

    public void OnPress()
    {
        Application.Quit();
    } 
}
