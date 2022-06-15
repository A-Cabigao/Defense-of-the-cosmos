using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletManager : Singleton<PlayerBulletManager>
{
    [SerializeField]
    Transform BulletPool;
    [SerializeField]
    GameObject BulletPrefab;
    [SerializeField]
    int bulletsToPool = 30;

    protected List<PlayerBullet> Bullets = new List<PlayerBullet>();

    Camera mainCam;

    protected override void Awake()
    {
        base.Awake();
        mainCam = Camera.main;
        Init();
    }

    void Init()
    {
        for (int i = 0; i < bulletsToPool; i++)
        {
            GameObject obj = Instantiate(BulletPrefab);
            obj.transform.SetParent(BulletPool);
            obj.SetActive(false);
            Bullets.Add(obj.GetComponent<PlayerBullet>());
        }
    }

    public void SpawnBullet(float speed, float time)
    {
        for (int i = 0; i < Bullets.Count; i++)
        {
            if (!BulletPool.GetChild(i).gameObject.activeInHierarchy)
            {
                //Bullets[i].Init(mainCam.transform.position, mainCam.transform.rotation, speed, time);
                break;
            }
        }
    }
}
