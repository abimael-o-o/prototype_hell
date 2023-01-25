using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamables : ObjInterface
{
    
    public void UseObj()
    {
        Debug.Log("Use");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Display Message: " +
                "Stash: E" + "Hold: F");
        }
    }
}
