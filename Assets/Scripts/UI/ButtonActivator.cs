using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonActivator : MonoBehaviour
{
    [SerializeField]
    GameObject[] Objects;

    bool activatedState = false;

    public void Interact()
    {
        activatedState = !activatedState;
        switch (activatedState)
        {
            case true:
                DeactivateObjsInArr();
                break;
            case false:
                ReactivateObjsInArr();
                break;
        }
    }

    public void DeactivateObjsInArr()
    {
        if (Objects.Length == 0) return;
        foreach(GameObject obj in Objects)
        {
            obj.SetActive(false);
        }
    }

    public void ReactivateObjsInArr()
    {
        if (Objects.Length == 0) return;
        foreach (GameObject obj in Objects)
        {
            obj.SetActive(true);
        }
    }
}
