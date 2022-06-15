using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField]
    Gradient hpGradient;

    MainTower mTower;

    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        image.fillAmount = 0f;
        mTower = GameManager.Instance.MTower;
    }

    public void FillHpBar()
    {
        LeanTween.value(image.fillAmount, 1f, 1f).setOnUpdate((float fill) => 
        {
            image.fillAmount = fill;
        });        
    }

    public void UpdateHpBar()
    {
        var amount = mTower.HPprcntToMax();

        image.fillAmount = amount;
        image.color = EvaluateGradient(amount);
    }

    Color EvaluateGradient(float amount)
    {
        return hpGradient.Evaluate(amount);
    }
}
