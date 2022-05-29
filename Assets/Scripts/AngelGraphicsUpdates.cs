using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AngelGraphicsUpdates : MonoBehaviour
{
    AIPath aiPath;
    Animator animator;

    

    void Start()
    {
        animator = GetComponent<Animator>();
        aiPath = GetComponentInParent<AIPath>();
    }

    void Update()
    {
        UpdateAnimation();
    }

    void UpdateAnimation() {
        bool goingLeft = aiPath.desiredVelocity.x < 0;
        bool goingRight = aiPath.desiredVelocity.x > 0;
        bool goingUp = aiPath.desiredVelocity.y > 0; 
        bool goingDown = aiPath.desiredVelocity.y < 0;

        bool xGreaterThanY = Mathf.Abs(aiPath.desiredVelocity.x) > Mathf.Abs(aiPath.desiredVelocity.y);
        this.animator.SetBool("isMovingLeft", goingLeft && xGreaterThanY);
        this.animator.SetBool("isMovingRight", goingRight && xGreaterThanY);        
        
        // We don't do diagonal. Don't have graphics for it
        this.animator.SetBool("isMovingUp", goingUp && !xGreaterThanY);
        this.animator.SetBool("isMovingDown", goingDown && !xGreaterThanY);
    }
}
