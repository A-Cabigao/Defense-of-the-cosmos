using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    [SerializeField]
    CanvasGroup group;
    [SerializeField]
    float fadeTime = 1f;

    private void Start()
    {
        AnimateTextAlpha();
        StartCoroutine(Loading());              
    }

    IEnumerator Loading()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync
            (MySceneManager.Instance.SceneToLoad, LoadSceneMode.Additive);

        while (!operation.isDone)
        {
            yield return null;
        }

        SceneTransition.Instance.PlayFadeInOut(0.15f);
        MySceneManager.Instance.UnloadLoadingScene();
    }

    void AnimateTextAlpha()
    {
        LeanTween.alphaCanvas(group, 0.25f, fadeTime).setLoopPingPong();
    }
}
