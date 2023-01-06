using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : Item
{

    [SerializeField] GoldUI _goldUI;

    public override void PickUp()
    {
        _goldUI.GiveGold();
        Destroy(gameObject);
    }
}
