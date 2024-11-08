using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class Utils
{
	public static T AddUniqueComponent<T>(this GameObject go) where T : Component
	{
		if (go.TryGetComponent<T>(out T component))
		{
			return component;
		}
		return go.AddComponent<T>();
	}
}
