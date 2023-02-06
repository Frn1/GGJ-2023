using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Checkpoint : MonoBehaviour
{
    public int checkpoint = 0;
    public bool invisible = false;
    
    [FormerlySerializedAs("_spriteRenderer")] [SerializeField] private SpriteRenderer spriteRenderer;

    private void Update()
    {
        if (checkpoint == 0 || invisible)
        {
            spriteRenderer.enabled = false;
            
        }
        else if (checkpoint == GameManager.instance.CurrentCheckpoint)
        {
            spriteRenderer.color = Color.green;
            
            
        }
        else
        {
            spriteRenderer.color = Color.red;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && checkpoint != 0)
        {
            GetComponent<Animation>().GetComponent<Animator>().enabled = true;
            GameManager.instance.CurrentCheckpoint = checkpoint;
        }
    }
}