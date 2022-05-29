using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class NPCSpawner : MonoBehaviour
{
    
    [SerializeField] List<GameObject> npcPrefabs;
    [SerializeField] int maxNPCs = 10;

    [SerializeField] WaypointManager waypointManager;

    void Start()
    {
        for (int i=0; i<=maxNPCs; i++){
            SpawnNPC();
        }
    }
    void Update()
    {
         Transform[] allChildren = GetComponentsInChildren<Transform>();
         while (allChildren.Length < maxNPCs) { 
            SpawnNPC();
            allChildren = GetComponentsInChildren<Transform>();
         }
    }

    void SpawnNPC() {
        if ((npcPrefabs != null) && (npcPrefabs.Count > 0) && (waypointManager != null)) {
            int npcIndex = Random.Range(0, npcPrefabs.Count - 1);
            GameObject npc = npcPrefabs[npcIndex];
            GameObject instance = Instantiate(npc, waypointManager.GetRandomDestination().position, Quaternion.identity, gameObject.transform);
            DestinationChecker checker = instance.GetComponent<DestinationChecker>();
            checker.SetWaypointManager(waypointManager);
            AIDestinationSetter aiSetter = instance.GetComponent<AIDestinationSetter>();
            aiSetter.target = waypointManager.GetRandomDestination();
            AIPath path = instance.GetComponent<AIPath>();
            path.speed = Random.Range(1, 5);
        }
    }
}
