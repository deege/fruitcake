using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Attack : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float firingRate = 1.0f;
    float distanceToTarget = 0.0f;
    Shooter shooter;
    Facing facing;
    AIPath aiPath;

    void Start() {
        shooter = GetComponent<Shooter>();
        facing = GetComponent<Facing>();
        aiPath = GetComponentInParent<AIPath>();
    }

    void Update()
    {
        if (facing != null) {
            Vector3 normDir = Vector3.Normalize(aiPath.desiredVelocity);
            facing.SetFacingByDirection(normDir);
        }
        if (target != null) {
            distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            if (distanceToTarget <= 12.0f) {
                if (shooter != null) {
                    shooter.isFiring = true;
                }
            } else {
                if (shooter != null) {
                    shooter.isFiring = false;
                }
            }
        }
    }
}
