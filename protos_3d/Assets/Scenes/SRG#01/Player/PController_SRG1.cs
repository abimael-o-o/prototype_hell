using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PController_SRG1 : Movement
{
    private void Awake()
    {
        PlayerInputActions inputActions = new PlayerInputActions();
        inputActions.Enable();
        inputActions.FPS_Player.Movement.performed += INPUT_VEL;
        inputActions.FPS_Player.Jump.performed += Player_Jump;
        inputActions.FPS_Player.Crouch.performed += Player_Crouch;
        inputActions.FPS_Player.Crouch.canceled += Player_Crouch;
    }
}
