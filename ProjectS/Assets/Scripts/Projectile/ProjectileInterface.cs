using UnityEngine;
public interface IProjectileTrajectory
{
    public void Trajectory(Projectile sourceProjectile, Vector3 targetPosition, float speed);
    public void StopMove(Projectile sourceProjectile);

}

public interface IAttackType
{
    public void Attack(IDamagable target, float damage);
}