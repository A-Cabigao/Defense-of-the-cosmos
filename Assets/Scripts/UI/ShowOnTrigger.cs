using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject ObjToShow;

    public void ShowObject()
    {
        var active = ObjToShow.activeInHierarchy;
        switch (active)
        {
            case true:
                ObjToShow.SetActive(false);
                break;
            case false:
                ObjToShow.SetActive(true);
                break;
        }
    }
}
