using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyManager : MonoBehaviour {
    //1
    public static EnemyManager Instance;
    //2
    public List<Enemy> Enemies = new List<Enemy>();
    //3
    void Awake()
    {
        Instance = this;
    }
    //4
    public void RegisterEnemy(Enemy enemy)
    {
        Enemies.Add(enemy);
    }
    //5
    public void UnRegister(Enemy enemy)
    {
        Enemies.Remove(enemy);
    }
    //6
    public List<Enemy> GetEnemiesInRange(Vector3 position, float range)
    {
        return Enemies.Where(enemy => Vector3.Distance(position,
        enemy.transform.position) <= range).ToList();
    }
    //7
    public void DestroyAllEnemies()
    {
        foreach (Enemy enemy in Enemies)
        {
            Destroy(enemy.gameObject);
        }
        Enemies.Clear();
    }



}
