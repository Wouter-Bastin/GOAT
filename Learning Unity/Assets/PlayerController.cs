using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float JumpForce;
    public float moveInputHorizontal;
    public float moveInputVertical;

    private Rigidbody2D rb;

    private bool facingRight = true;
    private bool facingUp = true;

    private bool isGroundedBottom;
    private bool isGroundedTop;
    public Transform groundCheck1;
    public Transform groundCheck2;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    private void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        isGroundedBottom = Physics2D.OverlapCircle(groundCheck1.position, checkRadius, whatIsGround);
        isGroundedTop = Physics2D.OverlapCircle(groundCheck2.position, checkRadius, whatIsGround);

        moveInputHorizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInputHorizontal * speed, rb.velocity.y);

        if (facingRight == false && moveInputHorizontal > 0)
        {
            Flipx();
        }
        else if (facingRight == true && moveInputHorizontal < 0)
        {
            Flipx();
        }
        else if(facingUp == false && isGroundedBottom == true)
        {
            Flipy();
        }
        else if(facingUp == true && isGroundedTop == true)
        {
            Flipy();
        }
    }

    private void Update()
    {
        if(isGroundedBottom == true || isGroundedTop == true)
        {
            extraJumps = extraJumpsValue;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * JumpForce;
            extraJumps--;
        } 
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && (isGroundedBottom || isGroundedTop))
        {
            rb.velocity = Vector2.up * JumpForce;
        }
        if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * JumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && (isGroundedBottom || isGroundedTop))
        {
            rb.velocity = Vector2.up * JumpForce;
        }
       
        if (Input.GetKeyDown(KeyCode.Space) && (isGroundedTop || isGroundedBottom))
        {
            rb.gravityScale *= -1;
        }
    }


    void Flipx()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    void Flipy()
    {
        
        Vector3 Scaler = transform.localScale;
        Scaler.y *= -1;
        transform.localScale = Scaler;
    }
   
}
