using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    [SerializeField] protected UnityEvent OnPickUp;
    public event Action OnItemPickedByPlayer;
    [SerializeField] Collider _collider;

    void Start()
    {
        OnItemPickedByPlayer += PickUp;
    }

    private void OnDisable()
    {
        OnItemPickedByPlayer -= PickUp;
    }

    public virtual void PickUp()
    {
        OnPickUp?.Invoke();
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.GetComponentInParent<PlayerMove>())
        {
            OnItemPickedByPlayer.Invoke();
        }
    }
}
