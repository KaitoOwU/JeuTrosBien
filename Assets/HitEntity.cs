using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEntity : MonoBehaviour
{
    List<EntityHealth> _listEntitiesInRange = new();
    public List<EntityHealth> ListEntitiesInRange { get => _listEntitiesInRange; }

    private void OnTriggerEnter(Collider c)
    {
        if (c.GetComponent<EntityHealth>())
        {
            ListEntitiesInRange.Add(c.GetComponent<EntityHealth>());
        }
    }

    private void OnTriggerExit(Collider c)
    {
        if(ListEntitiesInRange.Contains(c.GetComponent<EntityHealth>()))
        {
            ListEntitiesInRange.Remove(c.GetComponent<EntityHealth>());
        }
    }
}
