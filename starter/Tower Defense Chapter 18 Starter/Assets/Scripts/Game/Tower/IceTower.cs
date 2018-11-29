using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTower : Tower
{
    public GameObject icePrefab;

    //1
    private void GetNonFrozenTarget()
    {
        foreach (Enemy enemy in GetEnemiesInAggroRange())
        {
            if (!enemy.frozen)
            {
                targetEnemy = enemy;
                break;
            }
        }
    }
    //2
    protected override void AttackEnemy()
    {
        base.AttackEnemy();
        //3
        GameObject ice = (GameObject)Instantiate(icePrefab,
        towerPieceToAim.position, Quaternion.identity);
        ice.GetComponent<FollowingProjectile>().enemyToFollow = targetEnemy;
    }

    public override void Update()
    {
        base.Update();
        GetNonFrozenTarget();
    }

}
