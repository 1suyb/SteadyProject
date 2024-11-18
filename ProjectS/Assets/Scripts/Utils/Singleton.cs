using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
	private static T instance;
	public static T Instance
	{
		get
		{
			if (instance == null)
			{
				T manager = GameObject.FindObjectOfType<T>();
				if(manager == null)
				{
					GameObject go  = new GameObject(GameConfig.MANAGERNAME);
					manager = go.AddUniqueComponent<T>();
					DontDestroyOnLoad(go);
				}
				instance = manager;
			}
			return instance;
		}
	}
}
