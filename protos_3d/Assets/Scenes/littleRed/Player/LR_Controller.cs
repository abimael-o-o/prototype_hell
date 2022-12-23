using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LR_Controller : Movement
{
    public FootIK_Controller footIK;
    public void Awake()
    {
        PlayerInputActions playerInputActions = new PlayerInputActions();
        playerInputActions.FPS_Player.Enable();
        playerInputActions.FPS_Player.Movement.performed += INPUT_VEL;
        playerInputActions.FPS_Player.Jump.performed += Player_Jump;

        //playerInputActions.FPS_Player.L_Attack.performed += GetComponentInChildren<GunController>().Shoot;
    }
    public override void Player_Move()
    {
        base.Player_Move();
        footIK.ChangeFootPos();
    }
}
