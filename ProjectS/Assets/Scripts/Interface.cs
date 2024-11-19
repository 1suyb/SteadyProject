using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;


public interface ILoadable
{
	public void Load(int id);
}

public interface IDamagable
{
	public void TakeDamage(float damage);

}

public interface IRangedAttackable
{
	public void Shoot();
}