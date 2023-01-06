using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DangerZone : MonoBehaviour
{
    [SerializeField] private int _damageToEntities;

    List<EntityHealth> _listEntitiesInRange = new();
    public event Action OnTick;

    [SerializeField] UnityEvent OnTickGD;


    public List<EntityHealth> ListEntitiesInRange { get => _listEntitiesInRange; }

    Dictionary<EntityHealth, Coroutine> entityValues;

    private void OnTriggerEnter(Collider c)
    {
        if (c.GetComponentInParent<EntityHealth>() != null && c.tag == "Colider")
        {
            EntityHealth entityHealth = c.GetComponentInParent<EntityHealth>();
            entityHealth.DamageEntity(_damageToEntities);
            OnTickGD?.Invoke();
            OnTick?.Invoke();

            //Debug.Log("detected");

            //ListEntitiesInRange.Add(entityHealth);
            //Coroutine routine = StartCoroutine(DamageTickRoutine(entityHealth));

            //entityValues[entityHealth] = routine;
        }
    }

    private void OnTriggerExit(Collider c)
    {
        if (ListEntitiesInRange.Contains(c.GetComponentInParent<EntityHealth>()) && c.tag == "Colider")
        {
            //EntityHealth entityHealth = c.GetComponentInParent<EntityHealth>();

            //StopCoroutine(entityValues[entityHealth]);
            //ListEntitiesInRange.Remove(entityHealth);
            //entityValues.Remove(entityHealth);
        }
    }

    //IEnumerator DamageTickRoutine(EntityHealth entityHealth) //c'était trop bien mais tu là déjà fais ;-;
    //{
    //    while (true)
    //    {
    //        entityHealth.DamageEntity(10);
    //        yield return new WaitForSeconds(1);
    //    }
    //}
}
