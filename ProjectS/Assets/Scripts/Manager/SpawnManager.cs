using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    private Dictionary<string, Dictionary<int, GameObjectPool>> spawnedObjects =
        new Dictionary<string, Dictionary<int, GameObjectPool>>();

    public GameObject Spawn(string path, int id, Vector3 position = default,
        Quaternion rotation = default(Quaternion))
    {
        SetPool(path, id);
        GameObject go = spawnedObjects[path][id].TakeFromPool(position,rotation);
        return go;
    }

    public void SetPool(string path, int id, int minSize=0, int maxSize=10)
    {
        if (!spawnedObjects.ContainsKey(path))
        {
            spawnedObjects.Add(path, new Dictionary<int, GameObjectPool>());
        }
        if (!spawnedObjects[path].ContainsKey(id))
        {
            GameObject obj = Resources.Load<GameObject>($"Prefabs/{path}");
            spawnedObjects[path].Add(id, new GameObjectPool(obj, id, minSize:minSize, maxSize:maxSize));
        }
    }

    public GameObject SpawnEnemy(int id, Vector3 position = default,
        Quaternion rotation = default(Quaternion))
    {
        return Spawn("Enemy",id,position,rotation);
    }

    public GameObject SpawnTower(int id, Vector3 position = default,
        Quaternion rotation = default(Quaternion))
    {
        return Spawn("Tower",id,position,rotation);
    }

    public GameObject SpawnBullet(int id, Vector3 position = default, Quaternion rotation = default(Quaternion))
    {
        return Spawn("Bullet",id,position,rotation);
    }
}
