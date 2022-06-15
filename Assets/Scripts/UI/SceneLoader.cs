using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NaughtyAttributes;

public class SceneLoader : Singleton<SceneLoader>
{
    [Scene]
    public int sceneToLoad;

    // For objects such as buttons.
    public void LoadScene()
    {
        SceneTransition.Instance.PlayFadeInOut(0.75f, 
            ()=> SceneManager.LoadScene(sceneToLoad));      
    }
    
    // For in-code loading.
    public void LoadScene(int index)
    {
        SceneTransition.Instance.PlayFadeInOut(0.15f,
            ()=> SceneManager.LoadScene(index));
    }
}
