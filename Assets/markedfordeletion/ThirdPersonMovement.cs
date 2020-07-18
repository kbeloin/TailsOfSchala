﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
   public CharacterController controller;

   public float speed = 6f; 
        
    // Update is called once per framce
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical"); 
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
    
         if (direction.magnitude >= 0.1f)
        {
            float targetAngel = Mathf.Atan2(direction.x, direction.z);
           
            controller.Move(direction * speed * Time.deltaTime);
        }
    }
}
