using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    int direction = 0;

    public int Direction
    {
        get { return direction; }
        set { direction = value; }
    }

    float cameraSpeed = 40f;
    private void Update()
    {
        switch(direction)
        {
            case 1:
                transform.eulerAngles += Vector3.left * cameraSpeed * Time.deltaTime;
                break;
            case 2:
                transform.eulerAngles += Vector3.right * cameraSpeed * Time.deltaTime;
                break;
            case 3:
                transform.eulerAngles += Vector3.down * cameraSpeed * Time.deltaTime;
                break;
            case 4:
                transform.eulerAngles += Vector3.up * cameraSpeed * Time.deltaTime;
                break;
            default:
                break;
        }
    }
}
