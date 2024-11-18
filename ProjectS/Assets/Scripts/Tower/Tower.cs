using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private TowerInfo towerInfo;
    private WaitForSeconds waitForSeconds;
    private Collider[] detectedEnemies;

    public void Awake()
    {
        Init();
    }

    public void Init() // 추후 loadable로 변경
    {
        waitForSeconds = new WaitForSeconds(towerInfo.ShootIntervalTime);
        detectedEnemies = new Collider[towerInfo.MultiShoot];
        StartCoroutine(Detect());
    }

    public IEnumerator Detect()
    {
        while (true)
        {
            int detectCount = Physics.OverlapSphereNonAlloc(this.transform.position,towerInfo.DetectRange,detectedEnemies,LayerMask.GetMask("Enemy"));
            for (int i = 0; i < detectCount; i++)
            {
                GameObject bulletGO = SpawnManager.Instance.SpawnBullet(0,this.transform.position);
                Projectile bullet = bulletGO.GetComponent<Projectile>();
                bullet.Init(); // loadable이 붙고나면 지울 것
                bullet.Shoot(detectedEnemies[i].transform);
            }
            yield return waitForSeconds;
        }
    }
}
