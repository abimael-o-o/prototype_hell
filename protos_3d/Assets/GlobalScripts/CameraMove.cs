using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform cameraPosition;
    public void Update()
    {
        transform.position = cameraPosition.gameObject.transform.position;
    }
}
