using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorBinding : MonoBehaviour
{

    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private HitEntity _hitEntity;
    [SerializeField] private DangerZone _dangerZone;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        _playerMove.OnStartMove += SetWalkingAnimTrue;
        _playerMove.OnEndMove += SetWalkingAnimFalse;

        _hitEntity.OnHit += SetPlaterAttackTrigger;
        _dangerZone.OnTick += SetHitEntityTrigger;
    }

    private void SetWalkingAnimTrue()
    {
        _animator.SetBool("Walking", true);
    }

    private void SetWalkingAnimFalse()
    {
        _animator.SetBool("Walking", false);
    }

    private void SetPlaterAttackTrigger()
    {
        _animator.SetTrigger("Attack");
    }

    private void SetHitEntityTrigger()
    {
        _animator.SetTrigger("GetHit");
    }
}
