using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GK_Movement : Movement
{
    float turnSmoothvelocity;
    //Set up separate input
    private void Awake()
    {
        PlayerInputActions playerActions = new PlayerInputActions();
        playerActions.Enable();
        playerActions.ISOMETRIC_Player.Move.performed += INPUT_VEL;
        playerActions.ISOMETRIC_Player.Jump.performed += Player_Jump;
    }
    public override void Player_Move()
    {
        if (isGrounded() && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Move the player.
        Vector3 direction = new Vector3(vel_X, 0f, vel_Y);

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothvelocity, 0.1f);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(direction * moveSpeed * Time.deltaTime);
        }

        //Add gravity.
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
