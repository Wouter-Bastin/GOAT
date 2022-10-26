using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camNoRotation : MonoBehaviour
{
   
    void Start()
    {
        
    }

   
    void Update()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
