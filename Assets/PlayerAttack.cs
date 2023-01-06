using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] InputActionReference _attack;
    [SerializeField] int _damageDealt;
    [SerializeField] HitEntity _hitEntity;
    [SerializeField] float _cooldown;

    private void Start()
    {
        _attack.action.started += Attack;
    }

    private void OnDisable()
    {
        _attack.action.started -= Attack;
    }

    private void Attack(InputAction.CallbackContext obj)
    {
        IEnumerator AttackCoroutine()
        {
            while (obj.performed)
            {
                foreach(EntityHealth _h in _hitEntity.ListEntitiesInRange)
                {
                    _h.DamageEntity(_damageDealt);
                    yield return new WaitForSeconds(_cooldown);
                }
            }
        }
        StartCoroutine(AttackCoroutine());
    }
}
