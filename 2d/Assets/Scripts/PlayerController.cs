using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : InputManger
{
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    Rigidbody2D rb;

    private float speed = 4f;
    private bool isFacingRight;
    private float xH;
    private float jumpForce = 4f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }   
    public override void PlayerMove(float x)
    {
        this.xH = x;
        rb.velocity = new Vector2(xH * speed, rb.velocity.y);
        Flip();
    }
    public override void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }    
    }
    public override void PlayerAttack()
    {
        Debug.Log("Attack");
    }
    private void Flip()
    {
        if(isFacingRight && xH < 0f || !isFacingRight && xH > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
