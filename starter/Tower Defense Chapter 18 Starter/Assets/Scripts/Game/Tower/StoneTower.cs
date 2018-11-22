using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneTower : Tower {

    //1
    public GameObject stonePrefab;
    //2
    protected override void AttackEnemy()
    {
        base.AttackEnemy();
        //3
        GameObject stone = (GameObject)Instantiate(stonePrefab,
        towerPieceToAim.position, Quaternion.identity);

        stone.GetComponent<Stone>().enemyToFollow = targetEnemy;
        stone.GetComponent<Stone>().damage = attackPower;
    }
}
