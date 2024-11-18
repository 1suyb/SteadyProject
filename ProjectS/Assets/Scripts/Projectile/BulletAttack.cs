public class BulletAttack : IAttackType
{
    public void Attack(IDamagable target, float damage)
    {
        if(target != null)
            target.TakeDamage(damage);
    }
}