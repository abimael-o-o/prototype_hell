using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hPlayerControl : Movement
{
    private void Awake()
    {
        PlayerInputActions inputActions = new PlayerInputActions();
        inputActions.Enable();
        inputActions.FPS_Player.Movement.performed += INPUT_VEL;
        inputActions.FPS_Player.Run.performed += Player_Run;
        inputActions.FPS_Player.Run.canceled += Player_Run;
    }
}
