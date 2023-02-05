using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private string _baseText;
    private TextMeshProUGUI _textMeshPro;
    void Start()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        _baseText = _textMeshPro.text;
    }

    // Update is called once per frame
    void Update()
    {
        int coins = GameManager.instance.collectedCoins;
        int jumps = GameManager.instance.jumps;
        int deaths = GameManager.instance.deaths;
        _textMeshPro.SetText(_baseText, coins);
    }
}
