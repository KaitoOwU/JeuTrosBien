using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] int damageDealt;
    [SerializeField] HitEntity _hitEntity;

    void Attack()
    {
        foreach(EntityHealth _h in _hitEntity.ListEntitiesInRange)
        {
            _h.DamageEntity(damageDealt);
        }
    }
}
