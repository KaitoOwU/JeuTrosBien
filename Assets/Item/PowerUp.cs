using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Item
{
    [SerializeField] PlayerAttack _attack;
    public override void PickUp()
    {
        _attack.DamageDealth += 1;
        Destroy(gameObject);
    }
}
