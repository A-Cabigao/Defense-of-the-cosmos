using System.Collections.Generic;
using UnityEngine;

public class BulletManager : Singleton<BulletManager>
{
    [SerializeField]
    GameObject BulletPool;
    [SerializeField]
    GameObject BulletPrefab;
    [SerializeField]
    int bulletsToPool = 30;

    protected List<GameObject> bullets = new List<GameObject>();

    protected override void Awake()
    {
        base.Awake();
        Init();
    }

    void Init()
    {
        for(int i = 0; i <= bulletsToPool; i++)
        {
            GameObject bullet = Instantiate(BulletPrefab);
            bullet.SetActive(false);
            bullets.Add(bullet);
        }
    }

}
