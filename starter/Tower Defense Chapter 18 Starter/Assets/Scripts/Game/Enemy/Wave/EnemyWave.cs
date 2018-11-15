using System;
using System.Collections.Generic;
using UnityEngine;
//1
[Serializable]
public class EnemyWave
{
    //2
    public int pathIndex;
    //3
    public float startSpawnTimeInSeconds;
    //4
    public float timeBetweenSpawnsInSeconds = 1f;
    //5
    public List<GameObject> listOfEnemies = new List<GameObject>();
}