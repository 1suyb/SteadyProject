using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]private ProjectileInfo projectileInfo;
    private IAttackType attackType;
    private IProjectileTrajectory trajectory;

    public void Init()
    {
        attackType = new BulletAttack();
        trajectory = new LinearTrajectory();
    }

    public void Shoot(Vector3 targetPosition)
    {
        trajectory.Trajectory(this,targetPosition,projectileInfo.Speed);
    }

    private void OnCollisionEnter(Collision other)
    {
        attackType.Attack(other.gameObject.GetComponent<IDamagable>(), projectileInfo.AttackDamage);
        trajectory.StopMove(this);
    }
}

public class BulletAttack : IAttackType
{
    public void Attack(IDamagable target, float damage)
    {
        if(target != null)
            target.TakeDamage(damage);
    }
}

public class LinearTrajectory : IProjectileTrajectory
{
    private Coroutine coroutine;
    public void Trajectory(Projectile sourceProjectile, Vector3 targetPosition, float speed)
    {
        
        coroutine = sourceProjectile.StartCoroutine(Move(sourceProjectile.transform, targetPosition, speed));
    }

    private IEnumerator Move(Transform sourcePosition, Vector3 targetPosition, float speed)
    {
        Vector3 direction = targetPosition - sourcePosition.position;
        while (true)
        {
            sourcePosition.position += (Time.deltaTime * speed) * direction;
            
            // TODO : null 말고 다른걸로 바꾸기
            yield return null;
            if ((sourcePosition.position - targetPosition).magnitude < 0.1f)
            {
                break;
            }
        }
    }

    public void StopMove(Projectile sourceProjectile)
    {
        sourceProjectile.StopCoroutine(coroutine);
    }
    
}
