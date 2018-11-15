using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointManager : MonoBehaviour
{

    //1
    public static WayPointManager Instance;
    //2
    public List<Path> Paths = new List<Path>();
    void Awake()
    {
        //3
        Instance = this;
    }
    //4
    public Vector3 GetSpawnPosition(int pathIndex)
    {
        return Paths[pathIndex].WayPoints[0].position;
    }
}

//5
[System.Serializable]
public class Path
{
    public List<Transform> WayPoints = new List<Transform>();
}