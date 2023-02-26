using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour
{
    [SerializeField] bool isOpen;
    private bool canUseDoor = false;
    private float angle;
    private void Awake()
    {
        PlayerInputActions inputActions = new PlayerInputActions();
        inputActions.Enable();
        inputActions.ObjectActions.Use.performed += UseDoor;
    }

    private void OnTriggerStay(Collider other)
    {
        canUseDoor = true;
        if (!isOpen)
        {
            angle = 90f;
        }
        else
        {
            angle = -90f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canUseDoor = false;
    }
    public void UseDoor(InputAction.CallbackContext context)
    {
        if (canUseDoor)
        {
            this.transform.Rotate(Vector3.up, angle);
            isOpen = !isOpen;
        }
        
    }
    
}
