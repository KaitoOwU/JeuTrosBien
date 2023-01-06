using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{
    [SerializeField] EntityHealth _playerHealth;
    [SerializeField] int _amountHealed;

    public override void PickUp()
    {
        _playerHealth.Heal(_amountHealed);
        Destroy(gameObject);
    }

}
