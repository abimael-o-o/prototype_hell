using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tMoveController : Movement
{
    [SerializeField] Transform cam;
    [SerializeField] float turnSmoothTime = 0.1f;
    [SerializeField] Animator anim;
    float turnSmoothVelocity;
    private void Awake()
    {
        PlayerInputActions inputActions = new PlayerInputActions();
        inputActions.Enable();
        inputActions.ThirdPerson_Player.Movement.performed += INPUT_VEL;
        inputActions.ThirdPerson_Player.Jump.performed +=Player_Jump;
    }
    public override void Player_Move()
    {
        Vector3 dir = new Vector3(vel_X, 0f, vel_Y).normalized;
        if (dir.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * moveSpeed * Time.deltaTime);
            anim.Play("Walking"); //Set animator walk when moving
        }
        else
        {
            anim.Play("Idle");
        }

        
    }
}
