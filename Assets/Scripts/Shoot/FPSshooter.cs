using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSshooter : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    FPSsettings settings;

    Camera mainCam;

    public FPSsettings Settings => settings;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, mainCam.transform.position, mainCam.transform.rotation);      
    }
}
