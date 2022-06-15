using UnityEngine;
using UnityEngine.Events;

public class PointsManager : Singleton<PointsManager>
{
    [SerializeField]
    PointsText pointsText;

    public int Points { get; private set; } = 0;

    public void AddPoints(int value)
    {
        Points += value;
        pointsText.UpdateText(Points);

        if (Points % 10 == 0)
        {
            TowerManager.Instance.IncreaseBuyAllowance();
        }
    }
}
