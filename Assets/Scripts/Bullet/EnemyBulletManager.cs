using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletManager : Singleton<EnemyBulletManager>
{
    [SerializeField]
    Transform BulletPool;
    [SerializeField]
    GameObject BulletPrefab;
    [SerializeField]
    int bulletsToPool = 30;

    protected List<Bullet> Bullets = new List<Bullet>();

    protected override void Awake()
    {
        base.Awake();
        Init();
    }

    void Init()
    {
        for (int i = 0; i < bulletsToPool; i++)
        {
            GameObject obj = Instantiate(BulletPrefab);
            obj.transform.SetParent(BulletPool);
            obj.SetActive(false);
            Bullets.Add(obj.GetComponent<Bullet>());
        }
    }

    public void SpawnBullet(Vector3 startPos, Transform target, float damage, float speed)
    {
        for (int i = 0; i < Bullets.Count; i++)
        {
            if (!BulletPool.GetChild(i).gameObject.activeInHierarchy)
            {
                Bullets[i].Init(startPos, target, damage, speed);
                break;
            }
        }
    }
}
