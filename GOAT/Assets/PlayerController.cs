using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedGround;
    public float speedAir;
    private float speed;
    public float maxSpeed;
    public float JumpForce;
    public float moveInputHorizontal;
    private Animator anim;

    private Rigidbody2D rb;

    private bool facingRight = true;
    

    private bool isGroundedBottom;
    public Transform groundCheck1;
    public float checkRadius;
    public LayerMask whatIsGround;

    public float gravityStrength;
    public float Drag;
    public float XtraDragGround;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.drag = Drag;
        Physics2D.gravity = Vector2.down * gravityStrength;
    }
    private void FixedUpdate()
    {
        isGroundedBottom = Physics2D.OverlapCircle(groundCheck1.position, checkRadius, whatIsGround);

        if (isGroundedBottom)
        {
            rb.drag = Drag + XtraDragGround;
            speed = speedGround;
            anim.SetBool("falling", false);
        }
        else
        {
            rb.drag = Drag;
            speed = speedAir;
            anim.SetBool("falling", true);
        }

        moveInputHorizontal = Input.GetAxisRaw("Horizontal");

        if (Physics2D.gravity == Vector2.down * gravityStrength || Physics2D.gravity == Vector2.up * gravityStrength)
        {
            if (Mathf.Abs(moveInputHorizontal * speed) + Mathf.Abs(rb.velocity.y) < maxSpeed)
            {
                rb.velocity = new Vector2(moveInputHorizontal * speed + rb.velocity.x, rb.velocity.y);
            }

            else if (Mathf.Abs(moveInputHorizontal * speed) + Mathf.Abs(rb.velocity.y) >= maxSpeed)
            {
                rb.velocity = new Vector2(moveInputHorizontal * maxSpeed, rb.velocity.y);
            }
        }

        else if (Physics2D.gravity == Vector2.right * gravityStrength || Physics2D.gravity == Vector2.left * gravityStrength)
        {
            if (Mathf.Abs(moveInputHorizontal * speed) + Mathf.Abs(rb.velocity.y) < maxSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, moveInputHorizontal * speed + rb.velocity.y);
            }

            else if (Mathf.Abs(moveInputHorizontal * speed) + Mathf.Abs(rb.velocity.y) >= maxSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, moveInputHorizontal * maxSpeed);
            }
        }


        if (facingRight == false && moveInputHorizontal > 0 && ((Physics2D.gravity == Vector2.right * gravityStrength) || (Physics2D.gravity == Vector2.down * gravityStrength)))
        {
            Flipx();
        }
        else if (facingRight == true && moveInputHorizontal < 0 && ((Physics2D.gravity == Vector2.right * gravityStrength) || (Physics2D.gravity == Vector2.down * gravityStrength)))
        {
            Flipx();
        }
        else if (facingRight == true && moveInputHorizontal > 0 && ((Physics2D.gravity == Vector2.left * gravityStrength) || (Physics2D.gravity == Vector2.up * gravityStrength)))
        {
            Flipx();
        }
        else if (facingRight == false && moveInputHorizontal < 0 && ((Physics2D.gravity == Vector2.left * gravityStrength) || (Physics2D.gravity == Vector2.up * gravityStrength)))
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
