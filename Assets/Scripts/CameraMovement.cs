using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// From: [Mister Taft Creates] https://www.youtube.com/watch?v=NwsUxJ3kDR4&list=PL4vbr3u7UKWp0iM1WIfRjCDTI03u43Zfu&index=8&t=0s
public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;

    void Start()
    {
        
    }

    void FixedUpdate ()
    {
        if(transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
