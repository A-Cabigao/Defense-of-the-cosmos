using UnityEngine;

public class TaurusMovement : MovementRB
{
    Enemy enemy;

    protected override void Awake()
    {
        base.Awake();
        enemy = GetComponent<Enemy>();
        SetSpeed(enemy.Info.speed);
    }

    private void OnEnable()
    {
        SetTarget(enemy.targetTower);
    }

    private void FixedUpdate()
    {
        MoveToTarget();
        RotateToTarget();
    }
}
