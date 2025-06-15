using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    public float runSpeed = 10;
    public float jumpForce = 30;
    private SpriteRenderer spriteRenderer;
    public PlayerHealth health;
    public GroundChecker groundChecker;
    public Rigidbody2D rb;
    InventoryManager Inventory;
    private Vector3 input;
  
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Inventory = GameObject.Find("Canvas").GetComponent<InventoryManager>();
    }

    
    void Update()
    {

       if (health.isDead) return;

        Move();

        Jump();

    }

    public void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        float inputX = moveInput; 
        float inputY = Input.GetAxis("Vertical"); 

        Flip(moveInput);

        input = new Vector3(inputX, inputY, 0);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = new Vector2(moveInput * runSpeed, rb.velocity.y);
        }
        else
        {

            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }
    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && groundChecker.isGrounded)
        {

            rb.AddForce(Vector2.up * jumpForce);
        }
    }
    public void Flip(float moveInput)
    {
        if (moveInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    public bool IsMoving()
    {

        return input.x != 0;
    }

  /*public bool IsRunning()
    {
        return input.x!>=5;
    }*/

}
