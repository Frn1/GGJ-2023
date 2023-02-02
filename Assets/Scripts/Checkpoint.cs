using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Checkpoint : MonoBehaviour
{
    public int checkpoint = 0;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Update()
    {
        if (checkpoint == 0)
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
            GameManager.instance.currentCheckpoint = checkpoint;
        }
    }
}