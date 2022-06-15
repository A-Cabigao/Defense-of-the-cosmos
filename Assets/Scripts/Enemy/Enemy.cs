using UnityEngine;


public class Enemy : MonoBehaviour, IDamageable
{
    //[ReadOnly]
    // TODO: Make function that assigns this.
    public Transform targetTower;

    [SerializeField]
    EnemyInfo info;

    public EnemyInfo Info => info;

    public float CurrHP { get; private set; }

    public bool CanAttack { get; private set; } = false;

    PlaySFX playSfx;

    public void SetCanAttack(bool boo)
    {
        CanAttack = boo;
    }

    private void Awake()
    {
        playSfx = GetComponent<PlaySFX>();
    }

    private void Start()
    {
        CurrHP = info.hp;
    }

    private void Update()
    {
        if (!targetTower.gameObject.activeInHierarchy)
            targetTower = TowerManager.Instance.ClosestTower(transform);
    }

    private void OnDisable()
    {
        SetCanAttack(false);
    }

    public void Spawn(Transform tower)
    {
        targetTower = tower;
        gameObject.SetActive(true);
    }

    public void TakeDamage(float amount)
    {
        CurrHP -= amount;

        if (CurrHP < 1f)
            DieWithPoints();
    }

    public void Die()
    {
        TargetManager.Instance.RemoveTarget?.Invoke(transform);
        EnemySpawnManager.Instance.EnemyDied?.Invoke();
        gameObject.SetActive(false);
    }

    void DieWithPoints()
    {
        playSfx.PlayFirstClip();
        PointsManager.Instance?.AddPoints(info.pointsGiven);
        Die();
    }
}
