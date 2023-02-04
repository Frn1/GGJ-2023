using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Checkpoint : MonoBehaviour
{
    public int checkpoint = 0;

    public bool invisible = false;

    public string nextScene;
    
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Update()
    {
        if (checkpoint == 0 || invisible)
        {
            _spriteRenderer.enabled = false;
        }
        else if (checkpoint == GameManager.instance.currentCheckpoint)
        {
            _spriteRenderer.color = Color.green;
        }
        else
        {
            _spriteRenderer.color = Color.red;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && checkpoint != 0)
        {
            if (nextScene != null && nextScene.Trim().Length > 0)
            {
                Initiate.Fade(nextScene, Color.black, 2f);
            }
            GameManager.instance.currentCheckpoint = checkpoint;
        }
    }
}