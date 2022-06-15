using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTower : Tower
{
    public override void TakeDamage(float amount)
    {
        OnTakeDamage?.Invoke();
        CurrHP -= amount;

        if(CurrHP < 1f)
        {
            GameManager.Instance.End();
        }
    }
}
