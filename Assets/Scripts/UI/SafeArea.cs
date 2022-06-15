using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    RectTransform rect;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        ReSizeUI();
    }

    void ReSizeUI()
    {
        var safeArea = Screen.safeArea;
        var minAnchor = safeArea.position;
        var maxAnchor = minAnchor + safeArea.size;

        minAnchor.x /= Screen.width;
        minAnchor.y /= Screen.height;
        maxAnchor.x /= Screen.width;
        maxAnchor.y /= Screen.height;

        rect.anchorMin = minAnchor;
        rect.anchorMax = maxAnchor;
    }
}
