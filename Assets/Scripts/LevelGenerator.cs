using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    [FormerlySerializedAs("chunk")] public GameObject tree;
    public GameObject platformPrefab;
    public GameObject checkpoint;

    public int maxChunks = 5;
    public int chunksSpawned = 2;

    private int currentChunk = 0;

    private float lastPlatformX = 0;

    private float height = 0;

    // Start is called before the first frame update
    void Start()
    {
        Transform chunkTransform = tree.transform;
        var chunkHeight = chunkTransform.localScale.y;
        // height += chunkHeight / 2;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Chunk Spawner"))
        {
            GameObject[] objects = SceneManager.GetActiveScene().GetRootGameObjects();
            for (int i = 0; i < chunksSpawned; i++)
            {
                for (int j = 0; j < objects.Length; j++)
                {
                    Transform oldChunkTranform = objects[j].transform;
                    if (oldChunkTranform.gameObject.name == currentChunk.ToString())
                    {
                        Destroy(oldChunkTranform.gameObject);
                    }
                }
                Transform chunkTransform = tree.transform;
                var chunkHeight = chunkTransform.localScale.y;
                GameObject newChunk = new GameObject();
                GameObject chunkTree = Instantiate(tree, newChunk.transform);
                chunkTree.transform.position = new Vector3(0, chunkHeight / 2, 0);
                newChunk.transform.position = new Vector3(0, height, 0);
                newChunk.name = currentChunk.ToString();
                int platforms = Random.Range(10, 15);
                for (int j = 0; j < platforms; j++)
                {
                    float platformHeight = chunkHeight / platforms;
                    float platformX = Random.Range(-2.5f, 2.5f);
                    GameObject platform = Instantiate(platformPrefab, newChunk.transform);
                    platform.transform.localPosition = new Vector3(platformX, platformHeight * j + 5f, 0f);
                    if (platformX > 0)
                    {
                        platform.transform.Rotate(0f, 0f, 180f);
                    }

                    platform.transform.localScale = new Vector3(8f + Random.Range(-2, 0), 1, 1);
                    lastPlatformX = platformX;
                }
                transform.position = new Vector3(0, height + chunkHeight / 2, 0);
                height += chunkHeight;
                currentChunk += 1;
                currentChunk %= maxChunks;
            }
        }
    }
}