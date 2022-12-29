using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MJ122_Controller : Movement
{
    private void Awake()
    {
        PlayerInputActions playerActions = new PlayerInputActions();
        playerActions.Enable();
        playerActions.FPS_Player.Movement.performed += INPUT_VEL;
        playerActions.FPS_Player.Jump.performed += Player_Jump;
        playerActions.FPS_Player.L_Attack.performed += Attack_01;
    }
    public void Attack_01(InputAction.CallbackContext context)
    {
        Debug.Log("Attack");
    }
}
