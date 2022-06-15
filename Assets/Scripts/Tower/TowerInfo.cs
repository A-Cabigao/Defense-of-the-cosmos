using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "New Tower Info", menuName = "Game/Tower Info")]
public class TowerInfo : ScriptableObject
{
    public float hp;
    public float towerDamage;
    public float attackInterval;
    public float bulletSpeed;

    public bool aoeBullets;
    [ShowIf("aoeBullets")]
    public float aoeRadius;
}
