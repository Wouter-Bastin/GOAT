using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class gravitySwitch : MonoBehaviour
{

    public LayerMask whatIsPlayer;
    private bool contactPlayer;
    public Transform playerCheck;
    public float checkRadiusSwitch;
    public bool gravityRight;
    public bool gravityLeft;
    public bool gravityUp;
    public bool gravityDown;
    public float gravityStrength;

    public void Start()
    {


    }

    public void FixedUpdate()
    {
        contactPlayer = Physics2D.OverlapCircle(playerCheck.position, checkRadiusSwitch, whatIsPlayer);
    }

    public void Update()
    {
        if (contactPlayer == true && gravityRight == true)
        {

            Physics2D.gravity = Vector2.right * gravityStrength;
        }
        if (contactPlayer == true && gravityLeft == true)
        {
            Physics2D.gravity = Vector2.left * gravityStrength;
        }
        if (contactPlayer == true && gravityUp == true)
        {
            Physics2D.gravity = Vector2.up * gravityStrength;
        }
        if (contactPlayer == true && gravityDown == true)
        {
            Physics2D.gravity = Vector2.down * gravityStrength;

        }

    }
}
