using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndCheckpoint : MonoBehaviour
{
    public GameObject endScreen;
    public bool isEnd = false;
    public string nextScene;

    private Checkpoint _checkpoint;

    private bool showedEndScreen = false;

    void Start()
    {
        _checkpoint = GetComponent<Checkpoint>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _checkpoint.checkpoint != 0)
        {
            if (isEnd)
            {
                if (showedEndScreen == false)
                {
                    Time.timeScale = 0;
                    GameObject endScreenNew = Instantiate(endScreen);
                    endScreenNew.GetComponent<LevelEnd>().nextScene = nextScene;
                    showedEndScreen = true;
                }
            }
            else if (nextScene != null && nextScene.Trim().Length > 0)
            {
                Initiate.Fade(nextScene, Color.black, 2f);
            }
        }
    }
}