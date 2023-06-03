using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public float normalSpeed;
    public float fastSpeed;
    public Transform cam;
    public CharacterController controller;
    Vector3 movement;

    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity = 0.4f;

    bool grounded;
    Vector3 velocity; // <--This is just for Y velocity.
    float gravity = -9.81f;
    public float fallSmoothTime = 2f; //float value between 1f - 5f.

    public Transform groundCheck;
    public float groundDistance = 0.4f; //Radius of checkSphere.
    public LayerMask groundMask;

    public float jumpForce = 1f;
    public float jumpCoolDown;
    public float maxCoolDwn;
    public float jumpDT; // <--The amount of stamina being decreased from stamina after jump.

    //private Animator anim;
    float currentVelX;

    [Header("Stamina")]
    public float stamina;
    public float stDecreaseAmount = 1f;
    public float maxStamina;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //anim = GetComponentInChildren<Animator>();
        stamina = maxStamina;
    }

    void Update()
    {
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (!gameObject.GetComponent<PlayerAttack>().isAnimationPlaying())
        {


            //Debug.Log("Y Velocity" + velocity.y);
            //Takes in movement Input.
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.z = Input.GetAxisRaw("Vertical");
            Vector3 direction = movement.normalized;

            velocity.y = (velocity.y < -6f) ? -6f : velocity.y;

            //anim.SetFloat("Y Velocity", velocity.y); //Sets jumping "-3 and less is no jump"
                                                     //TODO: for Jump -- > when velocity.y is higher than -2 player is falling \\ Jumping animations is velocity.y dependent


            //Debug.Log("X Velocity" + currentVelX);

            //Moves the Player ---
            // && rotatees towards z-facing cam direction.
            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle,
                    ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * moveSpeed * Time.deltaTime);
            }

            //Running locomotion && stamina.
            if (Input.GetKey(KeyCode.LeftShift) && stamina > 0.5f)
            {
                //Faster running
                currentVelX = direction.magnitude * 2f;
                moveSpeed = fastSpeed;

                stamina -= stDecreaseAmount * Time.deltaTime; // <<--Decrease stamina.
                if (stamina < 0)
                {
                    stamina = 0;
                }
            }
            else
            {
                //Returns the player to normal speed.
                currentVelX = direction.magnitude;
                moveSpeed = normalSpeed;

                stamina += Time.deltaTime; // <--Regenerating stamina.
                jumpCoolDown += Time.deltaTime; // <--Regenerate jump stamina;

                //Caps the stamina to the max.
                //Can't exceed the maximum amount or else infinite run.
                stamina = (stamina > maxStamina) ? maxStamina : stamina;

                //Cap jump cooldown.
                jumpCoolDown = (jumpCoolDown > maxCoolDwn) ? maxCoolDwn : jumpCoolDown;
            }

            //anim.SetFloat("X Velocity", currentVelX, 0.1f, Time.deltaTime * 2f); //Running and walking

            //Jumping locomotion.
            //Linked to the player stamina*
            if (Input.GetButtonDown("Jump") && grounded)
            {
                if (stamina > 1f && jumpCoolDown == maxCoolDwn)
                {
                    //anim.Play("Jump"); //Jumping animation
                    velocity.y = Mathf.Sqrt(checkJumpCoolDown() * -2f * gravity); // <-- Adds up force to jump.
                    stamina -= jumpDT;
                    jumpCoolDown -= jumpDT;
                }
            }

        }
        //Adds Gravity for falling.
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * fallSmoothTime * Time.deltaTime);
    }

    public float checkJumpCoolDown()
    {
        if (jumpCoolDown < maxCoolDwn)
        {
            return 0f;
        }
        else
        {
            return jumpForce;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(groundCheck.position, groundDistance);
    }
}
