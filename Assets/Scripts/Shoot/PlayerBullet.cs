using NaughtyAttributes;
using System.Collections;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField]
    float speed = 30f;
    [SerializeField]
    float damage = 10f;
    [Tag]
    public string Tag;

    private void OnEnable()
    {
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        transform.position += (transform.forward * speed) * Time.deltaTime;
    }

    public void Init(Vector3 startPos, float time)
    {
        transform.position = startPos;
        StartCoroutine(TimedDisable(time));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(Tag))
        {
            collision.transform.GetComponent<IDamageable>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    IEnumerator TimedDisable(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
