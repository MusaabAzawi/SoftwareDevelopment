using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPathing : MonoBehaviour
{
    [Header("Pathing")]
    WaveConfig waveConfig;                                      // Wave configuration object
    List<Transform> waypoints;                                  // List of waypoints to follow
    int waypointIndex = 0;                                      // Starting waypoint index
    int carNumber = 0;                                          // Number of the car in the wave
    bool stop = false;

    // Start is called before the first frame update
    void Start()
    {
        // Set the position of the object to the starting waypoint
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (stop == false)
        {
            Move();
        }

        if (Input.GetKeyDown("space"))
        {
            stop = false;
            UnityEngine.Debug.Log("space key was pressed");
        }
    }

    // Set waveConfig variable
    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    // Set carNumber variable
    public void SetCarNumber(int index)
    {
        carNumber = index;
    }

    // Move object to waypoints
    private void Move()
    {
        // Object keep moving to each waypoint
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            // Checks if object posistion is the same as the target waypoint posisition
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
            if(carNumber == waveConfig.GetNumberOfCars() - 1)
            {
                waveConfig.SetHasStarted(false);
            }
        }
    }

    public void setStop(bool stop)
    {
        this.stop = stop;
        transform.position = new Vector2(transform.position.x, transform.position.y);
    }
}
