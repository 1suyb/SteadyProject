using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] private float speed;
	private Transform nextPoint;
	private int index;
	private Vector3 direction;

	private void Start()
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
        if ((nextPoint.position - this.transform.position).magnitude < 0.1f)
        {
            SetNextPoint();
        }
        this.transform.Translate(direction * Time.fixedDeltaTime*speed);
	}
	private void SetNextPoint()
	{
		if(index == WayPoints.Points.Length)
		{
			Goal();
		}
		nextPoint = WayPoints.Points[index++];
		direction = (nextPoint.position - this.transform.position).normalized;
	}
	private void Goal()
	{
		this.gameObject.SetActive(false);
	}
}
