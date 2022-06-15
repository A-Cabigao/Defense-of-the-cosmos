using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TowerManager : Singleton<TowerManager>
{
    [SerializeField]
    Transform[] towerSpawnLocations;
    [SerializeField]
    Button[] buttons;
    [SerializeField]
    GameObject buyTwrButton;

    int towerBuyAllowance = 0;

    int towerIndex = -1;

    AudioSource source;

    protected override void Awake()
    {
        base.Awake();
        source = GetComponent<AudioSource>();
    }

    public List<Transform> Towers { get; private set; } = new List<Transform>();

    public void AddTower(Transform Tower)
    {
        Towers.Add(Tower);
    }

    public void RemoveTower(Transform tower)
    {
        Towers.Remove(tower);
    }

    /// <summary>
    /// Returns a transform of tower from the list based on distance to reference.
    /// </summary>
    /// <param name="refT">Reference transform to compare distance to.</param>
    /// <returns></returns>
    public Transform ClosestTower(Transform refT)
    {
        if(Towers.Count > 0)
        {
            Transform tower = Towers[0];
            for(int i = 1; i < Towers.Count; i++)
            {
                if (Vector3.Distance(Towers[i].position, refT.position)
                    < Vector3.Distance(tower.position, refT.position))
                    tower = Towers[i];
            }
            return tower;
        }

        // Tower list is empty.
        return null;
    }

    public void SetTowerIndex(int value) => towerIndex = value;

    public void IncreaseBuyAllowance()
    {
        if (towerBuyAllowance < 4)
            towerBuyAllowance++;

        buyTwrButton.SetActive(true);
    }

    public void BuyTower(int index)
    {
        // index out of bounds
        if (index > 1 && index < 0) return;
        // TODO: determine currency of buying tower
        buttons[towerIndex].interactable = false;

        towerSpawnLocations[towerIndex].GetChild(index).gameObject.SetActive(true);
        ResetButton(towerSpawnLocations[towerIndex].GetChild(index).gameObject, towerIndex);
        source.Play();

        towerBuyAllowance--;

        if (towerBuyAllowance == 0)
            buyTwrButton.gameObject.SetActive(false);
    }

    IEnumerator ResetButton(GameObject obj, int twrIndx)
    {
        var check = obj.activeInHierarchy;
        while(check)
        {
            yield return null;
        }
        buttons[twrIndx].interactable = true;
    }
}
