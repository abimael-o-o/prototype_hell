using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    //FPS Player Camera.
    [SerializeField] float mouseSensitivity = 200f;
    [SerializeField] Transform playerBody;

    [SerializeField] float amplitude = 10f;
    [SerializeField] float period = 5f;
    Vector3 defaultPosY;

    float yRotation = 0f;
    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        defaultPosY = transform.localPosition;
    }

    void Update()
    {
        //CameraSway();

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    void CameraSway()
    {
        //Adds motion to the camera.
        float theta = Time.timeSinceLevelLoad / period;
        float distance = amplitude * Mathf.Sin(theta);
        transform.localPosition = defaultPosY + Vector3.up * distance;
    }
}
