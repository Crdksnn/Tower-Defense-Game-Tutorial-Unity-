using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBluePrint{

    public string turretTag;
    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;
    public GameObject rangeUIPrefab;

    public int GetSellAmount()
    {
        return cost / 2;
    }

}
