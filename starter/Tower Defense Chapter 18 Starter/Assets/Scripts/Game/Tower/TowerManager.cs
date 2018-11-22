using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class TowerManager : MonoBehaviour {

    [Serializable]
    public struct TowerCost
    {
        public TowerType TowerType;
        public int Cost;
    }

    //1
    public static TowerManager Instance;
    //2
    public GameObject stoneTowerPrefab;
    public GameObject fireTowerPrefab;
    public GameObject iceTowerPrefab;
    //3
    public List<TowerCost> TowerCosts = new List<TowerCost>();
    //4
    void Awake()
    {
        Instance = this;
    }
    //5
    public void CreateNewTower(GameObject slotToFill, TowerType towerType)
    {
        switch (towerType)
        {
            case TowerType.Stone:
                Instantiate(stoneTowerPrefab, slotToFill.transform.position,
                Quaternion.identity);
                slotToFill.gameObject.SetActive(false);
                break;

            case TowerType.Fire:
                Instantiate(fireTowerPrefab, slotToFill.transform.position,
                Quaternion.identity);
                slotToFill.gameObject.SetActive(false);
                break;
            case TowerType.Ice:
                Instantiate(iceTowerPrefab, slotToFill.transform.position,
                Quaternion.identity);
                slotToFill.gameObject.SetActive(false);
                break;
        }
    }
    //6
    public int GetTowerPrice(TowerType towerType)
    {
        return (from towerCost in TowerCosts
                where towerCost.TowerType
                == towerType
                select towerCost.Cost).FirstOrDefault();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
