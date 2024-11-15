using UnityEngine;

public static class ResourceManager 
{
	public static GameObject Instantiate(string path, Transform transform = null)
	{
		GameObject go = Resources.Load<GameObject>(path);
		return GameObject.Instantiate(go, transform);
	}
}
