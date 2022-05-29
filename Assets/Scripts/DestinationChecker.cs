using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class DestinationChecker : MonoBehaviour
{
    AIPath aiPath;
    AIDestinationSetter aiSetter;
    WaypointManager waypointManager;

    void Start() {
        aiPath = GetComponent<AIPath> ();
        aiSetter = GetComponent<AIDestinationSetter>();
    }

    public void SetWaypointManager( WaypointManager waypointManager) {
        this.waypointManager = waypointManager;
    }

    // Update is called once per frame
    void Update()
    {
        if (aiPath.reachedDestination) {
           
            aiSetter.target = waypointManager.GetRandomDestination();
        }
    }
}
