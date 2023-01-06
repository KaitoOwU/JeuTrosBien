using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEntity : MonoBehaviour
{
    List<EntityHealth> _listEntitiesInRange = new();

    public event Action OnHit;
    public List<EntityHealth> ListEntitiesInRange { get => _listEntitiesInRange; }

    private void OnTriggerEnter(Collider c)
    {
        if (c.GetComponentInParent<EntityHealth>())
        {
            ListEntitiesInRange.Add(c.GetComponentInParent<EntityHealth>());
            OnHit?.Invoke();
        }
    }

    private void OnTriggerExit(Collider c)
    {
        if(ListEntitiesInRange.Contains(c.GetComponentInParent<EntityHealth>()))
        {
            ListEntitiesInRange.Remove(c.GetComponentInParent<EntityHealth>());
        }
    }
}
