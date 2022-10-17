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

    private void Start()
    {
     
        
    }

    private void FixedUpdate()
    {
        contactPlayer = Physics2D.OverlapCircle(playerCheck.position, checkRadiusSwitch, whatIsPlayer);
    }

    private void Update()
    {
        if (contactPlayer == true && gravityRight == true)
        {
            Physics.gravity = new Vector3(1, 0, 0);
        }
        else if (contactPlayer == true && gravityLeft == true)
        {
            Physics.gravity = new Vector3(-1, 0, 0);
        }
        else if (contactPlayer == true && gravityUp == true)
        {
            Physics.gravity = new Vector3(0, 1, 0);
        }
        else if (contactPlayer == true && gravityDown == true)
        {
            Physics.gravity = new Vector3(0, -1, 0);
        }

    }
}
