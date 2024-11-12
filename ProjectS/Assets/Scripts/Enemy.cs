using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] private float speed;
	private StageManager _stageManager;
	private Transform nextPoint;
	private int index;
	private Vector3 direction;

	private void OnEnable()
	{
		Init();
	}
	private void Start()
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

	public void SetStageManager(StageManager stageManager)
	{
		_stageManager = stageManager;
	}

	private void Move()
	{
        if ((nextPoint.position - this.transform.position).magnitude < 0.1f)
        {
            SetNextPoint();
        }
        this.transform.Translate(direction * Time.fixedDeltaTime * speed);
	}
	private void SetNextPoint()
	{
		if(index == WayPoints.Points.Length)
		{
			Goal();
			return;
		}
		nextPoint = WayPoints.Points[index++];
		direction = (nextPoint.position - this.transform.position).normalized;
	}
	private void Goal()
	{
		this.gameObject.SetActive(false);
		_stageManager.AddFailCount();
	}

	public void Load(int id)
	{
		throw new System.NotImplementedException();
	}

	private void Die()
	{
		this.gameObject.SetActive(false);
	}

	private void OnDisable()
	{
		_stageManager.DiscountCurrentEnemyCount();
	}
}
