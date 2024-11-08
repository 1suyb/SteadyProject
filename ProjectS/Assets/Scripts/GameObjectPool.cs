using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PooledItem : MonoBehaviour
{
	GameObjectPool pool;
	public void Init(GameObjectPool pool,int id = -1)
	{
		this.pool = pool;
		if(this.gameObject.TryGetComponent<ILoadable>(out ILoadable loadable))
		{
			loadable.Load(id);
		}
	}
	private void OnDisable()
	{
		pool.Release(this.gameObject);
	}
}

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

	public GameObject TakeFromPool(Vector3 position = default)
	{
		GameObject go = IsPoolEmpty ? CreateItem() : pool.Pop();
		go.transform.position = position;
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
