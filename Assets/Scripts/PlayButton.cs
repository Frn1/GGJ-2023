using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public string firstLevel;

    public Image fader;

    private bool fading = false;
    private float _fade = 0f;

    public void Update()
    {
        if (fading)
        {
            fader.enabled = true;
            fader.color = new(0, 0 , 0, _fade * 2f);
            _fade += Time.deltaTime;
        }
    }

    public void OnPress()
    {
        fading = true;
        Initiate.Fade(firstLevel, Color.black, 2f);
    } 
}
