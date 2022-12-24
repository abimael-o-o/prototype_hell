using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MJ122_Controller : Movement
{
    private void Awake()
    {
        PlayerInputActions playerActions = new PlayerInputActions();
        playerActions.Enable();
        playerActions.FPS_Player.Movement.performed += INPUT_VEL;
        playerActions.FPS_Player.Jump.performed += Player_Jump;
    }
}
