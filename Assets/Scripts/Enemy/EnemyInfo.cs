using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "New Enemy Info", menuName = "Game/Enemy Info")]
public class EnemyInfo : ScriptableObject
{
    public float speed;
    public float hp;
    public float damageToTower;

    public int pointsGiven;

    [SerializeField]
    [Tooltip("Can this enemy attack from range?")]
    bool isAttacking = false;

    [ShowIf("isAttacking")]
    [Foldout("Range Attributes")]
    public float range = 10f;
    [ShowIf("isAttacking")]
    [Foldout("Range Attributes")]
    public float attackInterval = 0.25f;
    [ShowIf("isAttacking")]
    [Foldout("Range Attributes")]
    public float bulletSpeed = 15f;
}
