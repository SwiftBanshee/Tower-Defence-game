using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TowerType
{
    Stone, Fire, Ice
}

public class Tower : MonoBehaviour
{
    //1
    public float attackPower = 3f;
    //2
    public float timeBetweenAttacksInSeconds = 1f;
    //3
    public float aggroRadius = 15f;
    //4
    public int towerLevel = 1;
    //5
    public TowerType type;
    //6
    public AudioClip shootSound;
    //7
    public Transform towerPieceToAim;
    //8
    public Enemy targetEnemy = null;
    //9
    private float attackCounter;


    private void SmoothlyLookAtTarget(Vector3 target)
    {
        towerPieceToAim.localRotation = UtilityMethods.
        SmoothlyLook(towerPieceToAim, target);
    }
    protected virtual void AttackEnemy()
    {
        GetComponent<AudioSource>().PlayOneShot(shootSound, .15f);
    }

    //1
    public List<Enemy> GetEnemiesInAggroRange()
    {
        List<Enemy> enemiesInRange = new List<Enemy>();
        //2
        foreach (Enemy enemy in EnemyManager.Instance.Enemies)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position)
            <= aggroRadius)
            {
                enemiesInRange.Add(enemy);
            }
        }
        //3
        return enemiesInRange;
    }
    //4
    public Enemy GetNearestEnemyInRange()
    {
        Enemy nearestEnemy = null;
        float smallestDistance = float.PositiveInfinity;
        //5
        foreach (Enemy enemy in GetEnemiesInAggroRange())
        {
            if (Vector3.Distance(transform.position, enemy.transform.position)
            < smallestDistance)
            {
                smallestDistance = Vector3.Distance(transform.position,
                enemy.transform.position);
                nearestEnemy = enemy;
            }
        }
        //6
        return nearestEnemy;
    }

    public virtual void Update()
    {
        //1
        attackCounter -= Time.deltaTime;
        //2
        if (targetEnemy == null)
        {
            //3
            if (towerPieceToAim)
            {
                SmoothlyLookAtTarget(towerPieceToAim.transform.position -
                new Vector3(0, 0, 1));
            }
            //4
            if (GetNearestEnemyInRange() != null
            && Vector3.Distance(transform.position,
            GetNearestEnemyInRange().transform.position)
            <= aggroRadius)
            {
                targetEnemy = GetNearestEnemyInRange();
            }
        }
        else
        { // 5
          //6
            if (towerPieceToAim)
            {
                SmoothlyLookAtTarget(targetEnemy.transform.position);
            }
            //7
            if (attackCounter <= 0f)
            {
                // Attack
                AttackEnemy();
                // Reset attack counter
                attackCounter = timeBetweenAttacksInSeconds;
            }
            //8
            if (Vector3.Distance(transform.position,
            targetEnemy.transform.position) > aggroRadius)
            {
                targetEnemy = null;
            }
        }
    }

    public void LevelUp()
    {
        towerLevel++;
        //Calculate new stats for this tower
        attackPower *= 2;
        timeBetweenAttacksInSeconds *= 0.7f;
        aggroRadius *= 1.20f;
    }

    public void ShowTowerInfo()
    {
        UIManager.Instance.ShowTowerInfoWindow(this);
    }


}
