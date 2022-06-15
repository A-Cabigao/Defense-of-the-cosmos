using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class EnemyCollision : MonoBehaviour
{
    [Tag]
    public string tower;

    Enemy enemy;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals(tower))
            Collide(collision.transform);
    }

    void Collide(Transform tower)
    {
        tower.GetComponent<Tower>().TakeDamage(enemy.Info.damageToTower);
        enemy.Die();
    }
}
