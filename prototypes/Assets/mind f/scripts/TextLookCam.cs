using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLookCam : MonoBehaviour
{
    private Camera MainCamera;
    private void Start()
    {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + MainCamera.transform.forward);
    }
}
