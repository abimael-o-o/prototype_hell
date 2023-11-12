using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableWeapon : MonoBehaviour
{

    [SerializeField] KeyCode KEY;

    //Display the name of pickup obj, when the button displayed is pressed the 
    //player script will do the pick up action. This script only displays name 
    //and or the button keycode.
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            DisplayNameAndKey();
        }
    }

    //Display the name of weapon when in close proximity and action button to pick up.
    private void DisplayNameAndKey(){
        Debug.Log(gameObject.name);
    }

    public void PickUpKeyPressed(KeyCode key){
    }
}
