using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New FPS Settings", menuName = "Game/FPS settings")]
public class FPSsettings : ScriptableObject
{
    public float shootInterval;
    public float bulletSpeed;
    [Tooltip("Travel time before bullet disappears.")]
    public float bulletTravel;
}
