using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluePrint standartTurret;
    public TurretBluePrint missileLauncher;
    public TurretBluePrint laserTurret;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;    
    }

    public void SelectStandartTurret()
    {
        Debug.Log("Standart Turret Purchased");
        buildManager.SelectTurretToBuild(standartTurret);
    }

    public void SelectMissileTurret()
    {
        Debug.Log("Missile Turret Purchased");
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectLaserTurret()
    {
        Debug.Log("Laser Turret Purchased");
        buildManager.SelectTurretToBuild(laserTurret);
    }

}
