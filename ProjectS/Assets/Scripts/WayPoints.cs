using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
	private static Transform[] wayPoints;
	public static Transform[] Points
	{
		get {  return wayPoints.Skip(1).ToArray(); }
	}

	private void Awake()
	{
		wayPoints = gameObject.GetComponentsInChildren<Transform>();
	}
}
