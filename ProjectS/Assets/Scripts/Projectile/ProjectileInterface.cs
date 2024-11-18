using UnityEngine;
public interface IProjectileTrajectory
{
    public void Trajectory(Projectile sourceProjectile, Transform target, float speed);
    public void StopMove(Projectile sourceProjectile);

}

public interface IAttackType
{
    public void Attack(IDamagable target, float damage);
}