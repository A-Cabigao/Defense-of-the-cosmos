using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDisabler : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }
}
