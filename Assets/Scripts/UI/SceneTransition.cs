using UnityEngine;
using UnityEngine.UI;

public class SceneTransition : Singleton<SceneTransition>
{
    [SerializeField]
    private float fadeInTime = 0.35f;
    [SerializeField]
    private float fadeOutTime = 0.5f;

    RectTransform rect;

    protected override void Awake()
    {
        base.Awake();
        rect = GetComponent<RectTransform>();
        LeanTween.alpha(rect, 1f, 0f);             
    }

    private void Start()
    {
        PlayFadeOut();
    }

    public void PlayFadeIn()
    {
        LeanTween.alpha(rect, 1f, fadeInTime);
    }

    public void PlayFadeIn(System.Action OnTransitionEnd)
    {
        LeanTween.alpha(rect, 1f, fadeInTime).setOnComplete(OnTransitionEnd);
    }

    public void PlayFadeOut()
    {
        LeanTween.alpha(rect, 0f, fadeOutTime);
    }

    public void PlayFadeOut(System.Action OnTransitionEnd)
    {
        LeanTween.alpha(rect, 0f, fadeInTime).setOnComplete(OnTransitionEnd);
    }

    public void PlayFadeInOut(float time, System.Action OnFade = null)
    {
        LeanTween.alpha(rect, 1f, time).setOnComplete(() =>
        {
            OnFade?.Invoke();
            LeanTween.alpha(rect, 0f, time);
        });
    }

}
