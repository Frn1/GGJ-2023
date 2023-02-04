using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip sfx;

    private bool collected = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (collected == false && other.CompareTag("Player"))
        {
            collected = true;
            
            GameManager.instance.collectedCoins++;

            AudioManager.instance.PlaySfx(sfx);
        }
    }

    private void Update()
    {
        if (collected)
        {
            DestroyImmediate(gameObject);
        }
    }
}