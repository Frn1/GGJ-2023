using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    void Start()
    {
#if UNITY_WEBGL
        Destroy(gameObject);
#endif
    }

    private void Update()
    {
#if UNITY_WEBGL
        Destroy(gameObject);
#endif
    }

    public void OnPress()
    {
        Application.Quit();
    }
}