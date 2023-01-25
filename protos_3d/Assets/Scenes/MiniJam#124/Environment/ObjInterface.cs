using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInterface : MonoBehaviour
{
    public void HoldObj(Transform holdObj) 
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().freezeRotation = true;
        GetComponent<Rigidbody>().isKinematic = true;
        this.transform.position = holdObj.position;
        this.transform.parent = holdObj;
    }
}
