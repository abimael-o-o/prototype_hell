using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerCam;
    public Transform player;
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(
                                            player.position.x, playerCam.position.y, player.position.z), .2f);

        Quaternion newRotation = new Quaternion(playerCam.rotation.x, playerCam.rotation.y,
                                                        playerCam.rotation.z, player.rotation.w);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, .2f);
    }
}
