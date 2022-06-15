using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using NaughtyAttributes;

public class GameStarter : MonoBehaviour
{
    [SerializeField]
    float countdownTimer = 5f;
    [SerializeField]
    TextMeshProUGUI textMesh;
    [SerializeField]
    GameObject controls;
    [SerializeField]
    GameObject mainTower;

    public UnityEvent OnGameStart;

    bool isStopped = true;

    bool isStarted = false;
    
    [Button]
    public void StartOnClick()
    {
        StartGame();
        PointsManager.Instance.AddPoints(10);
        PointsManager.Instance.AddPoints(10);
        PointsManager.Instance.AddPoints(10);
    }

    public void StartCoundown()
    {
        if(isStarted)
        { return; }
        textMesh.gameObject.SetActive(true);
        isStopped = false;
        StartCoroutine(Countdown());
    }

    public void StopCountdown()
    {
        if(isStarted)
        { return; }
        textMesh.gameObject.SetActive(false);
        isStopped = false;
        StopAllCoroutines();
    }

    IEnumerator Countdown()
    {
        var timer = countdownTimer;
        while(!isStopped)
        {
            textMesh.text = timer.ToString();

            if(timer == 0)
            {
                StartGame();
                yield break;
            }
            yield return new WaitForSeconds(1f);
            timer--;
        }      
    }

    void StartGame()
    {
        OnGameStart?.Invoke();
        isStarted = true;
        textMesh.gameObject.SetActive(false);
        controls.SetActive(true);
        mainTower.SetActive(true);
        LeanTween.moveLocalY(mainTower, 13.1f, 1f).setOnComplete
            (() =>EnemySpawnManager.Instance.StartSpawn());
    }
}
