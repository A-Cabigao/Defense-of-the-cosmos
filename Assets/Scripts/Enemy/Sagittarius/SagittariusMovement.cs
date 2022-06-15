using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SagittariusMovement : MovementRB
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
        StartCoroutine(DieAfterInactive());
    }

    private void OnDisable()
    {
        ResumeMovement();
    }

    private void Update()
    {
        StopIfInRange();
    }

    private void FixedUpdate()
    {
        MoveToTarget();
        RotateToTarget();
    }

    IEnumerator DieAfterInactive()
    {
        yield return new WaitForSeconds(30f);
        enemy.Die();
    }

    void StopIfInRange()
    {
        if (!IsMoving()) 
            return;

        if (Vector3.Distance(transform.position, Target.position) < enemy.Info.range)
        { 
            enemy.SetCanAttack(true);
            StopMovement();
        }
    }
}
