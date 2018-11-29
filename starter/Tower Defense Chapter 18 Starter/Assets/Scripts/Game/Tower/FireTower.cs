using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : Tower {
    //1
    public GameObject fireParticlesPrefab;
    //2
    protected override void AttackEnemy()
    {
        //3
        base.AttackEnemy();
        //4
        GameObject particles = (GameObject)Instantiate(fireParticlesPrefab, transform.position + new Vector3(0, .5f), fireParticlesPrefab.transform.rotation);
        //5
        // Scale fire particle radius with the aggro radius
        particles.transform.localScale *= aggroRadius / 10f;
        //6
        foreach (Enemy enemy in EnemyManager.Instance.GetEnemiesInRange(
        transform.position, aggroRadius))
        {
            enemy.TakeDamage(attackPower);
        }
    }
}
