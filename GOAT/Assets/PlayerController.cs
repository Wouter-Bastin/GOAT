using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public float JumpForce;
    public float moveInputHorizontal;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGroundedBottom;
    public Transform groundCheck1;
    public float checkRadius;
    public LayerMask whatIsGround;

    public float gravityStrength;
    public float Drag;


    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        rb.drag = Drag;
        Physics2D.gravity = Vector2.down * gravityStrength;
    }
    private void FixedUpdate()
    {
        Debug.Log(isGroundedBottom);
        isGroundedBottom = Physics2D.OverlapCircle(groundCheck1.position, checkRadius, whatIsGround);

        moveInputHorizontal = Input.GetAxisRaw("Horizontal");

        if (Physics2D.gravity == Vector2.down * gravityStrength)
        {
            if (Mathf.Abs(moveInputHorizontal * speed) + Mathf.Abs(rb.velocity.y) < maxSpeed)
            {
                rb.velocity = new Vector2(moveInputHorizontal * speed + rb.velocity.x, rb.velocity.y);
            }

            else if (Mathf.Abs(moveInputHorizontal * speed) + Mathf.Abs(rb.velocity.y) >= maxSpeed)
            {
                rb.velocity = new Vector2(maxSpeed * moveInputHorizontal, rb.velocity.y);
            }
        }

        else if (Physics2D.gravity == Vector2.up * gravityStrength)
        {
            if (Mathf.Abs(moveInputHorizontal * speed) + Mathf.Abs(rb.velocity.y) < maxSpeed)
            {
                rb.velocity = new Vector2((moveInputHorizontal * speed)* -1 + rb.velocity.x, rb.velocity.y);
            }

            else if (Mathf.Abs(moveInputHorizontal * speed) + Mathf.Abs(rb.velocity.y) >= maxSpeed)
            {
                rb.velocity = new Vector2(maxSpeed * moveInputHorizontal * -1, rb.velocity.y);
            }
        }

        else if (Physics2D.gravity == Vector2.right * gravityStrength)
        {
            if (Mathf.Abs(moveInputHorizontal * speed) + Mathf.Abs(rb.velocity.y) < maxSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, moveInputHorizontal * speed + rb.velocity.y);
            }

            else if (Mathf.Abs(moveInputHorizontal * speed) + Mathf.Abs(rb.velocity.y) >= maxSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, maxSpeed * moveInputHorizontal);
            }
        }

        else if (Physics2D.gravity == Vector2.left * gravityStrength)
        {
            if (Mathf.Abs(moveInputHorizontal * speed) + Mathf.Abs(rb.velocity.y) < maxSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, (moveInputHorizontal * speed)* -1 + rb.velocity.y);
            }

            else if (Mathf.Abs(moveInputHorizontal * speed) + Mathf.Abs(rb.velocity.y) >= maxSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, (maxSpeed * moveInputHorizontal)* -1);
            }
        }



        if (facingRight == false && moveInputHorizontal > 0)
        {
            Flipx();
        }
        else if (facingRight == true && moveInputHorizontal < 0)
        {
            Flipx();
        }       

    }

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space) && (isGroundedBottom))
        {
            Physics2D.gravity *= -1;
        }

        if (Physics2D.gravity == Vector2.right * gravityStrength)
        {
            rb.transform.eulerAngles = new Vector3(0, 0, 90);
        }
        if (Physics2D.gravity == Vector2.left * gravityStrength)
        {
            rb.transform.eulerAngles = new Vector3(0, 0, -90);
        }
        if (Physics2D.gravity == Vector2.up * gravityStrength)
        {
            rb.transform.eulerAngles = new Vector3(0, 0, 180);
        }
        if (Physics2D.gravity == Vector2.down * gravityStrength)
        {
            rb.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

 
    void Flipx()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

   

}
