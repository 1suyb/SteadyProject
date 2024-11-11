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