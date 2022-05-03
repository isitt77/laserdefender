using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] WaveConfigSO waveConfig; // <-- Contains our public getters...
    List<Transform> waypoints;
    int waypointIndex = 0;  // <-- Sets our first waypoint at index 0...

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();
    }


    void FollowPath()
    {
        if(waypointIndex < waypoints.Count)
        {
            Vector3 targetPos = waypoints[waypointIndex].position;  // <-- Taget (next) position
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime; // <-- calling moveSpeed getter
            // Move towwards the target position from the current position at moveSpeed
            transform.position = Vector2.MoveTowards(transform.position, targetPos, delta); 
            if(transform.position == targetPos)
            {
                waypointIndex++; 
            }
        }
        else
        {
            Destroy(gameObject); // <-- because no more waypoints to move towards
        }
    }
}
