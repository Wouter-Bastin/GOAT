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

    public void Start()
    {
       
        
    }

    public void FixedUpdate()
    {
        contactPlayer = Physics2D.OverlapCircle(playerCheck.position, checkRadiusSwitch, whatIsPlayer);
        Debug.Log("Gravity is" + Physics.gravity);
        Debug.Log("contactPlayer is" + contactPlayer);
    }
    
    public void Update()
    {
        if (contactPlayer == true && gravityRight == true)
        {
            Physics.gravity = Vector2.right;
        }
        if (contactPlayer == true && gravityLeft == true)
        {
            Physics.gravity = Vector2.left;
        }
        if (contactPlayer == true && gravityUp == true)
        {
            Physics.gravity = Vector2.up;
        }
        if (contactPlayer == true && gravityDown == true)
        {
            Physics.gravity = Vector2.down;
        }
        
    }
}
