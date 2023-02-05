using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Checkpoint : MonoBehaviour
{
    public int checkpoint = 0;

    public bool invisible = false;

    public bool isEnd = false;
    public string nextScene;

    public bool hasKillZone = true;
    public Vector2 killZoneDistance = new Vector2(0, -17.5f);
    public float killZoneRotation = 0f;
    public GameObject killZone;

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
            if (checkpoint == GameManager.instance.currentCheckpoint)
            {
                GameObject newKillZone = Instantiate(killZone);
                Vector3 pos = transform.position;
                pos.x += killZoneDistance.x;
                pos.y += killZoneDistance.y;
                newKillZone.transform.position = pos;
                newKillZone.transform.rotation = new (0, 0 , killZoneRotation, 0);
                killZone.transform.localScale = new Vector3(50, 5, 1);
            }
        }
    }
}