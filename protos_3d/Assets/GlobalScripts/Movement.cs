using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public Transform groundCheck;
    public float moveSpeed;
    public LayerMask groundLayer;

    float vel_X;
    float vel_Y;

    private CharacterController controller;
    Vector3 moveDirection;
    Vector3 velocity;
    float gravity = -10f;
    public void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    public void Update()
    {
        Player_Move();
    }
    public virtual void Player_Move()
    {
        if(isGrounded() && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Move the player.
        Vector3 move = transform.right * vel_X + transform.forward * vel_Y;
        controller.Move(move * moveSpeed * Time.deltaTime);

        //Add gravity.
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    public virtual void Player_Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded())
        {
            Debug.Log("Jump");
        }
    }
    public void INPUT_VEL(InputAction.CallbackContext context)
    {
        vel_X = context.ReadValue<Vector2>().x;
        vel_Y = context.ReadValue<Vector2>().y;
    }
    public bool isGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.4f, groundLayer);
    }
    
}
