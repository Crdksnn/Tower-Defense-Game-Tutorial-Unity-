using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject shopUI;
    private Node turret;

    public Button upgradeButton;

    public Text upgradeCost;
    public Text sellAmount;

    public void SetTarget(Node node)
    {
        this.turret = node;
        transform.position = node.GetBuildPosition();

        if (!node.isUpgraded)
        {
            upgradeCost.text = "$" + node.turretBluePrint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "$" + node.turretBluePrint.GetSellAmount();

        shopUI.SetActive(true);
    }

    public void Hide()
    {
        shopUI.SetActive(false);
    }

    public void Upgrade()
    {
        turret.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        turret.SellTurret();
        BuildManager.instance.DeselectNode();
    }

}
