using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunController : MonoBehaviour
{
    public float Damage;
    public Transform crosshair;
    private void Update()
    {
        transform.LookAt(crosshair.position);
    }
    public virtual void Shoot(InputAction.CallbackContext context)
    {
        Debug.Log("Shoot");
    }
}
