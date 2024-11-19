using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat
{
	private readonly EnemyData baseStatData;
	public EnemyData CurrentStat { get; private set; }

	private int hp;
	public int HP
	{
		get => hp; 
		set 
		{
			hp = Mathf.Clamp(hp, 0, CurrentStat.HP);
			if (hp == 0)
			{
				OnDieEvent?.Invoke();
			}
		}
	}

	public event Action OnDieEvent;
	public EnemyStat(EnemyData baseStatData)
	{
		this.baseStatData = baseStatData;
		CurrentStat = baseStatData;
	}
}
