using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{

     List<Transform> waypoints;

    public Transform GetRandomDestination() {
        int index = Random.Range(0, waypoints.Count);
        return waypoints[index];
    }

    public List<Transform> GetWaypoints() {
        return waypoints;
    }

    void Awake()
    {
        waypoints = new List<Transform>();
        foreach (Transform child in transform) {
            waypoints.Add(child);
        } 
    }

}
