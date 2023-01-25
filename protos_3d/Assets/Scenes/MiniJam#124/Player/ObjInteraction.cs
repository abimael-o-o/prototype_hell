using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ObjInteraction : MonoBehaviour
{
    [SerializeField] Transform holdPosition;
    bool objectInRange;
    bool isHoldingObject = false;
    GameObject obj = null;

    private void Awake()
    {
        PlayerInputActions objActions = new PlayerInputActions();
        objActions.Enable();
        objActions.ObjectActions.Hold.performed += Hold;
        objActions.ObjectActions.Throw.performed += Throw;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "OBJ" && !isHoldingObject)
        {
            Debug.Log("obj");
            objectInRange = true;
            obj = other.gameObject;
        }
    }
    public void Hold(InputAction.CallbackContext context)
    {
        if(context.performed && obj != null && isHoldingObject)
        {
            UnparentObject();
        }

        if(context.performed && objectInRange && obj != null)
        {
            isHoldingObject = true;
            //obj.GetComponent<Rigidbody>().isKinematic = true;
            obj.GetComponent<Rigidbody>().useGravity = false;
            obj.transform.SetParent(holdPosition);
            obj.transform.localPosition = new Vector3(0f, 0f, 0f);
        }
    }
    public void Throw(InputAction.CallbackContext context)
    {
        if(isHoldingObject)
        {
            obj.GetComponent<Rigidbody>().AddForce(this.transform.forward * 10f, ForceMode.Impulse);
            UnparentObject();
        }
    }
    public void UnparentObject()
    {
        isHoldingObject = false;
        obj.GetComponent<Rigidbody>().useGravity = true;
        obj.transform.SetParent(null);
        obj = null;
    }
}
