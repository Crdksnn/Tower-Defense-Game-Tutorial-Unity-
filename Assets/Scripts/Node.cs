using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public GameObject turret = null;
    [HideInInspector]
    public TurretBluePrint turretBluePrint;
    [HideInInspector]
    public bool isUpgraded = false;

    Renderer rend;
    Color startColor;
    [SerializeField] Color hoverColor;
    [SerializeField] Color notEnoughMoneyColor;
    [SerializeField] Vector3 positionOffSet;
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        if (turret != null)
        {
            Instantiate(turret, transform.position, Quaternion.identity);
            return;
        }

    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffSet;
    }

    void BuildTurret(TurretBluePrint bluePrint)
    {
        if (bluePrint.turretTag == "Laser Turret")
            positionOffSet.y = -0.04f;

        if (PlayerStats.money < bluePrint.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        turretBluePrint = bluePrint;

        PlayerStats.money -= bluePrint.cost;

        GameObject _turret = (GameObject)Instantiate(bluePrint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject buildEffect = Instantiate(buildManager.buildEffectPrefab, GetBuildPosition(), Quaternion.identity);
        Destroy(buildEffect, 3f);

        Debug.Log("Turret build!");
    }

    public void UpgradeTurret()
    {
        if (turretBluePrint.turretTag == "Laser Turret")
            positionOffSet.y = -0.04f;

        if (PlayerStats.money < turretBluePrint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade that!");
            return;
        }

        PlayerStats.money -= turretBluePrint.upgradeCost;

        //Get rid of old turret
        Destroy(turret);

        //Build a new one
        GameObject _turret = (GameObject)Instantiate(turretBluePrint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject buildEffect = Instantiate(buildManager.buildEffectPrefab, GetBuildPosition(), Quaternion.identity);
        Destroy(buildEffect, 3f);

        isUpgraded = true;

        Debug.Log("Turret upgraded!");
    }

    public void SellTurret()
    {
        PlayerStats.money += turretBluePrint.GetSellAmount();

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(turret);
        turretBluePrint = null;
    }

    void OnMouseDown()
    {
        
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if(turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
