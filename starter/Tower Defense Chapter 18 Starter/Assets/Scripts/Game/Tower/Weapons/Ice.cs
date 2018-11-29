using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : FollowingProjectile
{

    protected override void OnHitEnemy()
    {
        enemyToFollow.Freeze();
        Destroy(gameObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
