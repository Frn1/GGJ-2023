using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    private TextMeshProUGUI _textMeshPro;

    private string _baseText = "";

    void Start()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        _baseText = _textMeshPro.text;
    }

    void Update()
    {
        int coins = GameManager.instance.collectedCoins;
        _textMeshPro.SetText(_baseText, coins);
    }
}