using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private ProjectileInfo projectileInfo;
    private IAttackType attackType;
    private IProjectileTrajectory trajectory;

    public void Init()
    {
        attackType = new BulletAttack();
        trajectory = new LinearTrajectory();
    }

    public void Shoot(Transform target)
    {
        trajectory.Trajectory(this,target,projectileInfo.Speed);
    }

    private void OnCollisionEnter(Collision other)
    {
        attackType.Attack(other.gameObject.GetComponent<IDamagable>(), projectileInfo.AttackDamage);
        trajectory.StopMove(this);
        this.gameObject.SetActive(false);
    }
}