using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputManger : MonoBehaviour
{
    private KeyCode jumpKey = KeyCode.Space;
    public virtual void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        PlayerMove(x);
        PlayerJump();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayerAttack();
        }
    }

    public abstract void PlayerMove(float x);
    public abstract void PlayerJump();
    public abstract void PlayerAttack();
}
