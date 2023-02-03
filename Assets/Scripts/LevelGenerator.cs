using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    public GameObject chunk;
    public GameObject platformPrefab;

    public int maxChunks = 5;
    public int chunksSpawned = 2;

    private int currentChunk = 0;

    private float lastPlatformX = 0;
    
    private float height = 0;

    // Start is called before the first frame update
    void Start()
    {
        Transform chunkTransform = chunk.transform;
        var chunkHeight = chunkTransform.localScale.y;
        height += chunkHeight / 2;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Chunk Spawner"))
        {
            for (int i = 0; i < chunksSpawned; i++)
            {
                if (transform.childCount >= maxChunks)
                {
                    for (int j = 0; j < transform.childCount; j++)
                    {
                        Transform oldChunkTranform = transform.GetChild(j);
                        if (oldChunkTranform.gameObject.name == currentChunk.ToString())
                        {
                            Destroy(oldChunkTranform.gameObject);
                        }
                    }
                }
                Transform chunkTransform = chunk.transform;
                var chunkHeight = chunkTransform.localScale.y;
                GameObject newChunk = Instantiate(chunk, transform.parent);
                newChunk.transform.position = new Vector3(0, height, 0);
                newChunk.name = currentChunk.ToString();
                int platforms = Random.Range(5, 8);
                for (int j = 0; j < platforms; j++)
                {
                    float platformX = Random.Range(-6, 6);
                    GameObject platform = Instantiate(platformPrefab, newChunk.transform);
                    platform.transform.position = new Vector3(platformX, (chunkHeight / platforms) * j);
                    platform.transform.localScale /= 4;
                }
                height += chunkHeight;
                transform.position = new Vector3(0, height, 0);
                currentChunk += 1;
                currentChunk %= 5;
            }
        }
    }
}
