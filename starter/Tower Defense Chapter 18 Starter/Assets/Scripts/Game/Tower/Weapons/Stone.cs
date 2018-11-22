using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : FollowingProjectile {

    //1
    public float damage;
    //2
    protected override void OnHitEnemy()
    {
        //3
        enemyToFollow.TakeDamage(damage);
        Destroy(gameObject);
    }
}
