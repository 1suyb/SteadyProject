using System.Collections;
using UnityEditor;
using UnityEngine;

public class LinearTrajectory : IProjectileTrajectory
{
    private Projectile projectile;
    private Coroutine coroutine;
    
    public LinearTrajectory(Projectile projectile)
    {
        this.projectile = projectile;
    }
    public void Trajectory(Projectile sourceProjectile, Transform target, float speed)
    {
        coroutine = sourceProjectile.StartCoroutine(Move(sourceProjectile.transform, target, speed));
    }

    private IEnumerator Move(Transform sourcePosition, Transform target, float speed)
    {
        Vector3 targetPosition = target.position;
        Vector3 direction = target.position - sourcePosition.position;
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
		projectile.gameObject.SetActive(false);
    }

    public void StopMove(Projectile sourceProjectile)
    {
        sourceProjectile.StopCoroutine(coroutine);
    }
    
}