using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

public class EnemySpawnManager : Singleton<EnemySpawnManager>
{
    public UnityEvent EnemyDied;

    [SerializeField]
    [Tooltip("Maximum number of enemies that can be in play.")]
    public int maxActiveEnemies = 3;

    public int maxEnemiesToPool = 15;

    [Foldout("Fields")] [Required]
    [SerializeField]
    SpawnBox spawnBox;
    [Foldout("Fields")] [Required]
    [SerializeField]
    Transform enemyPoolParent;

    [SerializeField]
    GameObject[] enemyPrefabs;
    [ReadOnly]
    public List<Enemy> Enemies = new List<Enemy>();

    protected override void Awake()
    {
        EnemyDied.AddListener(SpawnEnemy);
    }

    private void Start()
    {
        InitializeEnemies();
    }

    private void OnDestroy()
    {
        EnemyDied.RemoveAllListeners();
    }

    public void SetMaxEnemyCount(int value)
    {
        if(value > maxActiveEnemies)
        {
            for (int i = maxActiveEnemies; i < value; i++)
            {
                SpawnEnemy();
            }
        }

        maxActiveEnemies = value;
    }

    public void StartSpawn()
    {
        for (int i = 0; i < maxActiveEnemies; i++)
            SpawnEnemy();
    }

    void InitializeEnemies()
    {
        for(int i = 0; i < maxEnemiesToPool; i++)
        {
            GameObject obj = Instantiate
                (enemyPrefabs[Random.Range(0, enemyPrefabs.Length)]);
            obj.transform.SetParent(enemyPoolParent);
            obj.SetActive(false);
            Enemies.Add(obj.GetComponent<Enemy>());
        }       
    }

    void SpawnEnemy()
    {
        for(int i = 0; i < Enemies.Count; i++)
        {
            var rand = Random.Range(0, Enemies.Count - 1);
            if (!Enemies[rand].gameObject.activeInHierarchy)
            {
                Enemies[rand].transform.position = spawnBox.RandomPos();
                Enemies[rand].Spawn(TowerManager.Instance.ClosestTower(Enemies[rand].transform));
                break;
            }
        }       
    }
}
