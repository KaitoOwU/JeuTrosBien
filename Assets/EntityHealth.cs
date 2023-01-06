using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{

    [SerializeField] int _maxHealth;

    public int CurrentHealth { get; private set; }
    public int MaxHealth { get => _maxHealth; private set => _maxHealth = value; }

    public event Action<int> OnHealthChange;

    internal void DamageEntity(int damageDealt)
    {
        Debug.Log("ssf");
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
        OnHealthChange?.Invoke(CurrentHealth);   
    }



}
