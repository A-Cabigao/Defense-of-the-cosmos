using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Transform target;
    float damage;
    float speed;

    bool dealAoe = false;
    float damageRadius;

    public void Init(Vector3 startPos, Transform target, float damage, float speed)
    {
        transform.position = startPos;
        this.target = target;
        this.damage = damage;
        this.speed = speed;
        gameObject.SetActive(true);
        StartCoroutine(TimedDisable());
    }

    public void Init(Vector3 startPos, Transform target, float damage, float speed, bool isAoe, float aoeRadius)
    {
        transform.position = startPos;
        this.target = target;
        this.damage = damage;
        this.speed = speed;
        dealAoe = isAoe;
        damageRadius = aoeRadius;
        gameObject.SetActive(true);
        StartCoroutine(TimedDisable());
    }

    private void Update()
    {
        Move();   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (dealAoe)
            DamageAOE(collision.transform);
        else
            DamageEntity(collision.transform);


        DisableBullet();
    }

    void DamageEntity(Transform entity)
    {
        IDamageable damageable = entity.GetComponent<IDamageable>();
        if (entity != null)
            damageable.TakeDamage(damage);
    }

    void DamageAOE(Transform entity)
    {
        RaycastHit[] hit = Physics.SphereCastAll(entity.position, damageRadius, entity.position);

        for (int i = 0; i < hit.Length; i++)
        {
            IDamageable damageable = hit[i].transform.GetComponent<IDamageable>();
            if(damageable != null)
            {
                if (damageable is Enemy)
                    damageable.TakeDamage(damage);
            }
        }
    }

    void Move()
    {
        if (!gameObject.activeInHierarchy) return;
        if (target != null)
            transform.position = Vector3.MoveTowards(transform.position, target.position,
                speed * Time.deltaTime);
        else
            DisableBullet();
    }

    IEnumerator TimedDisable()
    {
        yield return new WaitForSeconds(2f);
        DisableBullet();
    }

    void DisableBullet()
    {
        gameObject.SetActive(false);
    }

}
