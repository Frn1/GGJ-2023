using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public string nextScene;
    private BackButton _backButton;
    
    void Start()
    {
        _backButton = gameObject.GetComponentInChildren<BackButton>();
    }

    // Update is called once per frame
    void Update()
    {
        _backButton.sceneName = nextScene;
    }
}
