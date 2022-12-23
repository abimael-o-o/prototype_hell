using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootIK_Controller : MonoBehaviour
{
    Vector3 previousPos;
    public Transform hintPos_R;
    private void Start()
    {
        previousPos = transform.position;
    }
    public void ChangeFootPos()
    {
        transform.position = previousPos;
        if (Vector3.Distance(hintPos_R.position, transform.position) > 1)
        {
            previousPos = hintPos_R.position;
        }
    }
}
