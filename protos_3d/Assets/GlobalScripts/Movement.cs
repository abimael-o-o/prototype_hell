using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public Transform groundCheck;
    public float moveSpeed;
    public LayerMask groundLayer;

    public float vel_X { get; set; } 
    public float vel_Y { get; set; }

    public CharacterController controller;
    //Vector3 moveDirection;
    public Vector3 velocity;
    public Vector3 move { get; set; }
    public float gravity = -10f;
    public float jumpForce = 10f;
    public void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    public void Update()
    {
        AddGravity();
        Player_Move();
    }
    public virtual void AddGravity()
    {
        if(isGrounded() && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        //Add gravity.
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    public virtual void Player_Move()
    {
        //Move the player.
        move = transform.right * vel_X + transform.forward * vel_Y;
        controller.Move(move * moveSpeed * Time.deltaTime);
    }
    public virtual void Player_Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded())
        {
            velocity.y += jumpForce;
            controller.Move(velocity * Time.deltaTime);
        }
    }
    public virtual void Player_Crouch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            controller.height = controller.height * .5f;
            groundCheck.position = new Vector3(0, 0.4f, 0);
        }
        if (context.canceled)
        {
            controller.height = 2f;
            groundCheck.position = new Vector3(0, 0, 0);
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
