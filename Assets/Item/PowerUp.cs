using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerUp : Item
{
    [SerializeField] PlayerAttack _attack;
    
    public override void PickUp()
    {
        OnPickUp?.Invoke();
        _attack.DamageDealth += 1;
        Destroy(gameObject);
    }
}
