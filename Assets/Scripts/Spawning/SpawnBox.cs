using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBox : MonoBehaviour
{
    [SerializeField]
    Transform start;
    [SerializeField]
    Transform end;

    [SerializeField]
    Transform limitStart;
    [SerializeField]
    Transform limitEnd;

    [SerializeField]
    Color spawnerColor = Color.red;
    [SerializeField]
    Color limitColor = Color.blue;

    public Vector3 RandomPos()
    {
        var randX = Random.Range(start.position.x, end.position.x);

        // X position is inside the limit
        if(randX > limitStart.position.x && randX < limitEnd.position.x)
        { 
            return new Vector3(randX, transform.position.y, Random.Range(limitEnd.position.z,
                end.position.z));
        }
        else
            return new Vector3(randX, transform.position.y, 
                Random.Range(start.position.z, end.position.z));
    }  

    private void OnDrawGizmos()
    {
        DrawSpawn();
        DrawLimit();
    }

    void DrawSpawn()
    {
        Debug.DrawLine(start.position, new Vector3(start.position.x, transform.position.y, end.position.z), spawnerColor);
        Debug.DrawLine(new Vector3(start.position.x, transform.position.y, end.position.z), end.position, spawnerColor);
        Debug.DrawLine(end.position, new Vector3(end.position.x, transform.position.y, start.position.z), spawnerColor);
        Debug.DrawLine(new Vector3(end.position.x, transform.position.y, start.position.z), start.position, spawnerColor);
    }

    void DrawLimit()
    {
        Debug.DrawLine(limitStart.position, new Vector3(limitStart.position.x, transform.position.y, limitEnd.position.z), limitColor);
        Debug.DrawLine(new Vector3(limitStart.position.x, transform.position.y, limitEnd.position.z), limitEnd.position, limitColor);
        Debug.DrawLine(limitEnd.position, new Vector3(limitEnd.position.x, transform.position.y, limitStart.position.z), limitColor);
        Debug.DrawLine(new Vector3(limitEnd.position.x, transform.position.y, limitStart.position.z), limitStart.position, limitColor);
    }
}
