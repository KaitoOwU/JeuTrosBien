using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

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
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.GetComponentInParent<PlayerMove>())
        {
            OnItemPickedByPlayer.Invoke();
        }
    }
}
