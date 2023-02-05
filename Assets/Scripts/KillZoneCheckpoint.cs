using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZoneCheckpoint : MonoBehaviour
{
    public bool hasKillZone = true;
    public Vector2 killZoneDistance = new Vector2(0, -17.5f);
    public float killZoneRotation = 0f;
    public GameObject killZone;

    private Checkpoint _checkpoint;

    void Start()
    {
        _checkpoint = GetComponent<Checkpoint>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _checkpoint.checkpoint != 0)
        {
            if (_checkpoint.checkpoint == GameManager.instance.CurrentCheckpoint)
            {
                GameObject newKillZone = Instantiate(killZone);
                Vector3 pos = transform.position;
                pos.x += killZoneDistance.x;
                pos.y += killZoneDistance.y;
                newKillZone.transform.position = pos;
                newKillZone.transform.rotation = new(0, 0, killZoneRotation, 0);
                killZone.transform.localScale = new Vector3(50, 5, 1);
            }
        }
    }
}