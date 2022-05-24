using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    Vector2 moveInput;
    Rigidbody2D rigidbody2d;
    Animator animator;

    [SerializeField] float moveSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimation();
        Run();
    }

    void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
    }

    void Run() {
        rigidbody2d.velocity = moveInput * moveSpeed ;
    }

    void UpdateAnimation() {
        animator.SetBool("isMovingUp", moveInput.y > 0);
        animator.SetBool("isMovingDown", moveInput.y < 0);
        animator.SetBool("isMovingLeft", moveInput.x < 0);
        animator.SetBool("isMovingRight", moveInput.x > 0);
    }
}
