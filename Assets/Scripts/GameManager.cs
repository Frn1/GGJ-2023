using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform player;

    private static GameManager _instance;

    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Game Manager is null :(");
            }

            return _instance;
        }
    }

    public int collectedCoins = 0;

    public bool gameOver
    {
        set
        {
            _gameOver = value;
            if (_gameOver)
            {
                tpToCheckpoint(currentCheckpoint);
            }
        }
        get { return _gameOver; }
    }

    public int currentCheckpoint = 0;

    private bool _gameOver = false;

    private void tpToCheckpoint(int number)
    {
        bool found = false;
        var scene = SceneManager.GetActiveScene();
        GameObject[] rootGameObjects = scene.GetRootGameObjects();
        foreach (GameObject rootGameObject in rootGameObjects)
        {
            Checkpoint checkpoint;
            for (int i = 0; i < rootGameObject.transform.childCount; i++)
            {
                GameObject gameObject = rootGameObject.transform.GetChild(i).gameObject;
                if (gameObject.TryGetComponent<Checkpoint>(out checkpoint))
                {
                    if (checkpoint.checkpoint == number)
                    {
                        _gameOver = false;
                        player.position = checkpoint.transform.position;
                        player.GetComponent<Rigidbody2D>().velocity = new Vector2();
                        found = true;
                    }

                }
                if (found)
                {
                    break;
                }
            }
            if (found)
            {
                break;
            }
            if (rootGameObject.TryGetComponent<Checkpoint>(out checkpoint))
            {
                if (checkpoint.checkpoint == number)
                {
                    _gameOver = false;
                    player.position = checkpoint.transform.position;
                    player.GetComponent<Rigidbody2D>().velocity = new Vector2();
                    break;
                }
            }
        }
    }
    
    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        tpToCheckpoint(0);
    }
}