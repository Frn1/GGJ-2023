using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
    public bool gameOver = false;

    private void Awake()
    {
        _instance = this;
    }
}
