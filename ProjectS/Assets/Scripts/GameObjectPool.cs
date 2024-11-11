using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class GameObjectPool
{
	private Stack<GameObject> pool = new Stack<GameObject>();
	private GameObject targetObject;
	private int id;
	private readonly int MAXSIZE;
	private readonly int MINSIZE;
	private int poolSize;

	public bool IsPoolEmpty => pool.Count == 0;

	public GameObjectPool(GameObject targetObejct, int id=-1, int minSize=0, int maxSize=10)
	{
		this.targetObject = targetObejct;
		this.id = id;
		this.MINSIZE = minSize;
		this.MAXSIZE = maxSize;

		for(int i = 0; i < MINSIZE; i++)
		{
			CreateItem().SetActive(false);
		}
	}

	public GameObject TakeFromPool(Vector3 position = default, Quaternion rotation = default(Quaternion))
	{
		GameObject go = IsPoolEmpty ? CreateItem() : pool.Pop();
		go.transform.position = position;
		go.transform.rotation = rotation;
		go.SetActive(true);
		return go;
	}

	private GameObject CreateItem()
	{
		GameObject go = GameObject.Instantiate(targetObject);
		PooledItem pooledItem = go.AddUniqueComponent<PooledItem>();
		pooledItem.Init(this, id);
		poolSize++;
		return go;
	}
	
	public void Release(GameObject go)
	{
		if(poolSize > MAXSIZE)
		{
			GameObject.Destroy(go);
			poolSize--;
			return;
		}
		pool.Push(go);
	}


}
