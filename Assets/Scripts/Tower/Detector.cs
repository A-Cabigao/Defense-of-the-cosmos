using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Detector : MonoBehaviour
{
    [Tag] 
    public string enemyTag;

    [ReadOnly]
    public List<Transform> detectedEnemies = new List<Transform>();

    private void OnEnable()
    {
        TargetManager.Instance.AddListener(RemoveFromList);
    }

    private void OnDisable()
    {
        if(TargetManager.Instance != null)
            TargetManager.Instance.RemoveListener(RemoveFromList);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(enemyTag))
            EnemyDetect(other.transform);
    }

    void EnemyDetect(Transform enemy)
    {
        if (detectedEnemies.Contains(enemy))
            return;
        else
        {
            detectedEnemies.Add(enemy);
        }
    }

    void RemoveFromList(Transform enemy)
    {
        if (!(detectedEnemies.Contains(enemy)))
            return;
        else
        {
            detectedEnemies.Remove(enemy);
        }
    }
}
