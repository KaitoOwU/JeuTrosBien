using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    public int GoldAmount { get; private set; }

    public event Action OnGoldChange;

    internal void GiveGold()
    {
        GoldAmount++;
        OnGoldChange.Invoke();
    }

    private void Start()
    {
        OnGoldChange += UpdateUI;
        GoldAmount = 0;
        OnGoldChange.Invoke();
    }

    private void UpdateUI()
    {
        _text.text = $"Gold : {GoldAmount}";
    }
}
