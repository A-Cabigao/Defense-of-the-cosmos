using UnityEngine;
using UnityEngine.Events;

public abstract class Tower : MonoBehaviour, IDamageable
{
    public UnityEvent OnTakeDamage;
    [SerializeField]
    TowerInfo info;

    public TowerInfo Info => info;

    public float CurrHP { get; protected set; }

    private void Start()
    {
        CurrHP = info.hp;
    }

    private void OnEnable()
    {
        TowerManager.Instance.AddTower(transform);
    }

    private void OnDisable()
    {
        TowerManager.Instance?.RemoveTower(transform);
    }

    /// <summary>
    /// Get percent of current hp to max hp.
    /// </summary>
    /// <returns>float</returns>
    public float HPprcntToMax()
    {
        return CurrHP / info.hp;
    }

    public virtual void TakeDamage(float amount)
    {
        CurrHP -= amount;

        if(CurrHP < 1f)
        {
            gameObject.SetActive(false);
        }
    }
}
