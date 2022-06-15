using System;
using UnityEngine;
using NaughtyAttributes;

public class GameManager : Singleton<GameManager>
{
    public static Action OnGameStart;
    public static Action OnGameEnd;

    [Scene]
    public int gameOverScene;

    [SerializeField]
    MainTower tower;

    public MainTower MTower 
    { get { return tower; } }

    public void End()
    {
        OnGameEnd?.Invoke();
        SceneLoader.Instance?.LoadScene(gameOverScene);
    }
}
