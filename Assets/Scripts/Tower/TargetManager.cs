using System;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : Singleton<TargetManager>
{
    public Action<Transform> RemoveTarget;

    List<Action<Transform>> listeners = new List<Action<Transform>>();

    private void Start()
    {
        
    }

    private void OnDestroy()
    {
        RemoveAllDelegates();
    }

    public void AddListener(Action<Transform> method)
    {
        RemoveTarget += method;
        listeners.Add(method);
    }

    public void RemoveListener(Action<Transform> method)
    {
        RemoveTarget -= method;
        listeners.Remove(method);
    }

    void RemoveAllDelegates()
    {
        if (listeners.Count == 0)
            return;
        else
        {
            for(int i = 0; i < listeners.Count; i++)
            {
                RemoveTarget -= listeners[i];
            }
        }
    }

}
