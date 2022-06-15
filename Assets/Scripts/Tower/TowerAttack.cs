using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    Tower tower;
    Detector detector;

    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    Transform bulletSpawn;

    Transform target;

    private void Awake()
    {
        tower = transform.parent.GetComponent<Tower>();
        detector = GetComponent<Detector>();

        InvokeRepeating("Attack", 0.1f, tower.Info.attackInterval);
    }

    void Attack()
    {
        if (!tower.gameObject.activeInHierarchy)
            CancelInvoke();
        if (detector.detectedEnemies.Count == 0)
            return;

        if(tower.Info.aoeBullets)
        {
            TowerBulletManager.Instance.SpawnBullet
                (bulletSpawn.position,
                detector.detectedEnemies[0],
                tower.Info.towerDamage,
                tower.Info.bulletSpeed,
                tower.Info.aoeBullets,
                tower.Info.aoeRadius);

        }
        else
        {
            TowerBulletManager.Instance.SpawnBullet
                (bulletSpawn.position,
                detector.detectedEnemies[0],
                tower.Info.towerDamage,
                tower.Info.bulletSpeed);
        }       
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
