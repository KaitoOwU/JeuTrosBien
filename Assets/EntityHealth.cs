using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{

    [SerializeField] int _maxHealth;

    public int CurrentHealth { get; private set; }

    public event Action<int> OnHealthChange;

    internal void DamageEntity(int damageDealt)
    {
        CurrentHealth -= damageDealt;
        OnHealthChange.Invoke(CurrentHealth);

        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        CurrentHealth = _maxHealth;
    }



}
