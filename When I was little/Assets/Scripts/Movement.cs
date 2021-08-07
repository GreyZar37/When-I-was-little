using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform isGroundedChecker;
    public Rigidbody2D rb;

    float horizontal;
    public float speed = 5f;
    public float jumpForce = 5f;
    public float checkGroundRadius;

    bool facingRight;
    bool isGrounded = false;

    Animator animator;

    public LayerMask groundLayer, objectLayer;

    bool isMoving;

    void Start()
    {
        if(GameManager.wasInBedroom == true)
        {
            if(KeysCollect.keysCollected == 1)
            {
                gameObject.transform.position = new Vector3(25, -4, 0);

            }
        }
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(horizontal != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;

        }
        flip();
        jump();
        groundCheck();
        objectCheck();
    }

    private void FixedUpdate()
    {
        movement();


    }
    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
    void groundCheck()
    {
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
      
        
        if (collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    void objectCheck()
    {
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, objectLayer);


        if (collider != null)
        {
            isGrounded = true;
        }
      
    }
    void movement()
    {
        horizontal = Input.GetAxis("Horizontal");
        animator.SetBool("Moving", isMoving);
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    void flip()
    {

        if(horizontal < -0.1)
        {
            facingRight = true;
        }
        else if( horizontal > 0.1)
        {
            facingRight = false;
        }





        if (facingRight == true)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }
        else if (facingRight == false)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
    }
}
