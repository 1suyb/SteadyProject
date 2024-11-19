using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	private Enemy enemy;
	private Transform nextPoint;
	private int index;
	private Vector3 direction;

	private void Awake()
	{
		enemy = GetComponent<Enemy>();
	}
	private void OnEnable()
	{
		Init();
	}
	private void Init()
	{
		index = 0;
		SetNextPoint();
	}


	private void FixedUpdate()
	{
		Move();
	}



	private void Move()
	{
		if ((nextPoint.position - this.transform.position).magnitude < 0.3f)
		{
			SetNextPoint();
		}
		this.transform.position += direction * Time.fixedDeltaTime * enemy.Stat.CurrentStat.Speed;
	}
	private void SetNextPoint()
	{
		if (index == WayPoints.Points.Length)
		{
			enemy.Goal();
			return;
		}
		nextPoint = WayPoints.Points[index++];
		direction = (nextPoint.position - this.transform.position).normalized;
	}
}
