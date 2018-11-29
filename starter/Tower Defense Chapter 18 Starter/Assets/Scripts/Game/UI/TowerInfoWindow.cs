using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerInfoWindow : MonoBehaviour {

    public Tower tower;
    //2
    public Text txtInfo;
    public Text txtUpgradeCost;
    //3
    private int upgradePrice;
    //4
    private GameObject btnUpgrade;


    //1
    void Awake()
    {
        btnUpgrade = txtUpgradeCost.transform.parent.gameObject;
    }

    //2
    void OnEnable()
    {
        UpdateInfo();
    }
    private void UpdateInfo()
    {
        // Calculate new price for upgrade
        //3
        upgradePrice = Mathf.CeilToInt(TowerManager.Instance.
        GetTowerPrice(tower.type) * 1.5f * tower.towerLevel);
        //4
        txtInfo.text = tower.type + " Tower Lv " + tower.towerLevel;
        //5
        if (tower.towerLevel < 3)
        {
            btnUpgrade.SetActive(true);
            txtUpgradeCost.text = "Upgrade\n" + upgradePrice + " Gold";
        }
        else
        {
            btnUpgrade.SetActive(false);
        }
    }

    //6
    public void UpgradeTower()
    {
        if (GameManager.Instance.gold >= upgradePrice)
        {
            GameManager.Instance.gold -= upgradePrice;
            tower.LevelUp();
            gameObject.SetActive(false);
        }
    }

}
