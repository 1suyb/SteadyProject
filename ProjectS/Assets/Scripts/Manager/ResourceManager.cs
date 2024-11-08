using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
	public GameObject Instantiate(string path, Transform transform = null)
	{
		GameObject go = Resources.Load<GameObject>(path);
		return GameObject.Instantiate(go, transform);
	}
}
