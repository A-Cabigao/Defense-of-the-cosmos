using UnityEngine;
using TMPro;

public class PointsText : MonoBehaviour
{
    TextMeshProUGUI pointsText;

    private void Awake()
    {
        pointsText = GetComponent<TextMeshProUGUI>();        
    }

    public void UpdateText(int points)
    {
        pointsText.text = points.ToString(string.Format("00000000"));
    }
}
