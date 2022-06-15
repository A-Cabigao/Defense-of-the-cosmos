using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : Singleton<MySceneManager>
{
    public int SceneToLoad { get; private set; } = -1;

    public void SetSceneToLoad(int value)
    {
        if (value < 0)
        {
            Debug.LogError("Scene index cannot be lower than 0. Returning to Main menu.");
            SceneToLoad = 0;
        }
        else
        {
            SceneToLoad = value;
        }      
    }

    public void UnloadLoadingScene()
    {
        SceneManager.UnloadSceneAsync("Loading");
    }
}
