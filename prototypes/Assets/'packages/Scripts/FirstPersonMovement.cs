using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;

    CharacterController character;
    float gravity = -9.81f;
    Vector3 velocity; //Only used for gravity movement.

    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    void Awake()
    {
        character = GetComponent<CharacterController>();
    }
    void Update()
    {
        // Update IsRunning from input.
        IsRunning = canRun && Input.GetKey(runningKey);

        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Get targetVelocity from input.
        Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Apply movement.
        Vector3 direction = transform.rotation * new Vector3(targetVelocity.x, 0, targetVelocity.y);
        character.Move(direction.normalized * targetMovingSpeed * Time.deltaTime);


        velocity.y += gravity * Time.deltaTime;
        character.Move(velocity * 2f * Time.deltaTime);
    }
}