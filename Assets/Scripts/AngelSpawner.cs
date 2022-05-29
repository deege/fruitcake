using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AngelSpawner : MonoBehaviour
{

    [SerializeField] List<GameObject> angelPrefabs;
    [SerializeField] int startingAngels = 5;
    [SerializeField] WaypointManager waypointManager;
    [SerializeField] GameObject player;

    Coroutine respawnCoroutine;
    bool isSpawnStarted = false;


    void Start() {
        for (int i=0; i<=startingAngels; i++){
            SpawnAngel();
        }
    }

    void Update()
    {
        if (!isSpawnStarted) { 
            DoDelaySpawn(Random.Range(3.0f, 5.0f));
        } else {
            StopCoroutine(respawnCoroutine);
        }
        Invoke("SpawnAngel", Random.Range(5, 10));
    }

    public void SpawnAngel() {
        DamageDealer[] allChildren = GetComponentsInChildren<DamageDealer>();
        Debug.Log("Angels = " + allChildren.Length);
        if (allChildren.Length <= startingAngels) {
            if ((angelPrefabs != null) && (angelPrefabs.Count > 0) && (waypointManager != null)) {
                int angelIndex = Random.Range(0, angelPrefabs.Count);
                GameObject angel = angelPrefabs[angelIndex];
                GameObject instance = Instantiate(angel, waypointManager.GetRandomDestination().position, Quaternion.identity, gameObject.transform);
                AIDestinationSetter aiSetter = instance.GetComponent<AIDestinationSetter>();
                aiSetter.target = player.transform;
                AIPath path = instance.GetComponent<AIPath>();
                path.speed = Random.Range(2, 5);
                Attack attack = instance.GetComponent<Attack>();
                attack.target = player;
            }
        }
    }

    void DoDelaySpawn(float delayTime)
    {
        isSpawnStarted = true;
        respawnCoroutine = StartCoroutine(DelaySpawn(delayTime));
    }
    
    IEnumerator DelaySpawn(float delayTime)
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);
        SpawnAngel();
        isSpawnStarted = false;
    }
}
