using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public string sceneName;
    public void OnClick()
    {
        Initiate.Fade(sceneName, Color.black, 2f);
    }
}
