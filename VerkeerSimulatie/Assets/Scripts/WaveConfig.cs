using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Car Wave Config")]
public class WaveConfig : ScriptableObject
{
    [Header("Config params")]
    [SerializeField] GameObject carPrefab;                  // Car to use
    [SerializeField] GameObject pathPrefab;                 // Path to follow
    [SerializeField] float timeBetweenSpawns = 0.5f;        // Spawn timer
    [SerializeField] float spawnRandomFactor = 0.3f;        // Random spawn factor
    [SerializeField] int numberOfCars = 2;                  // Number of cars to spawn
    [SerializeField] float moveSpeed = 2f;                  // Move speed of the cars

    bool hasStarted = false;                                // Checks if wave has started

    public GameObject GetCarPrefab()
    {
        return carPrefab;
    }

    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();
        foreach(Transform waypoint in pathPrefab.transform)
        {
            waveWaypoints.Add(waypoint);
        }
        return waveWaypoints;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int GetNumberOfCars()
    {
        return numberOfCars;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public bool GetHasStarted()
    {
        return hasStarted;
    }

    public void SetHasStarted(bool hasStarted)
    {
        this.hasStarted = hasStarted;
    }
}
