using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] InputActionReference _attack;
    [SerializeField] int _damageDealt;
    [SerializeField] HitEntity _hitEntity;
    [SerializeField] float _cooldown;
    [SerializeField] UnityEvent OnAttack;

    public int DamageDealth { get => _damageDealt; set => _damageDealt = value; }


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

            while (obj.ReadValueAsButton())
            {
                _animator.SetTrigger("Attack");
                foreach(EntityHealth _h in _hitEntity.ListEntitiesInRange)
                {
                    _h.DamageEntity(_damageDealt);
                    OnAttack.Invoke();
                }
                yield return new WaitForSeconds(_cooldown);
            }
        }
        StartCoroutine(AttackCoroutine());
    }
}
