using UnityEngine;

public class SagittariusAttack : MonoBehaviour
{
    [SerializeField]
    Transform bulletSpawn;
    // Debug only
    [SerializeField]
    GameObject bulletPrefab;

    Enemy enemy;

    AudioSource source;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        InvokeRepeating("Attack", 0.1f, enemy.Info.attackInterval);
    }

    void Attack()
    {
        if (!enemy.gameObject.activeInHierarchy)
            CancelInvoke();
        if (!enemy.CanAttack) return;

        source.Play();
        EnemyBulletManager.Instance.SpawnBullet(bulletSpawn.position, enemy.targetTower,
            enemy.Info.damageToTower, enemy.Info.bulletSpeed);
    }
}
