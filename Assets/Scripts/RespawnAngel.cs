using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnAngel : MonoBehaviour
{
    
    [SerializeField] AngelSpawner spawn;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy() {
        // Debug.Log("DESTROY");
        // if (spawn != null) {
        //     spawn.SpawnAngel();
        // }
    }

}
