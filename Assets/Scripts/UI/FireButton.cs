using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class FireButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    FPSshooter shooter;
    float currentShootTime = 0f;
    bool isPressed = false;

    private void Awake()
    {
        shooter = GetComponent<FPSshooter>();
    }

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        shooter.Shoot();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        currentShootTime = 0f;
    }

    IEnumerator Shoot()
    {
        while(true)
        {
            if(isPressed)
            {
                currentShootTime += Time.deltaTime;

                if(currentShootTime > shooter.Settings.shootInterval)
                {
                    shooter.Shoot();
                    currentShootTime = 0f;
                }
            }
            yield return null;
        }
    }
}
