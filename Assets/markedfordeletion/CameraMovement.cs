using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// From: [Mister Taft Creates] https://www.youtube.com/watch?v=NwsUxJ3kDR4&list=PL4vbr3u7UKWp0iM1WIfRjCDTI03u43Zfu&index=8&t=0s
public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;

    void Start()
    {
        
    }

    void FixedUpdate ()
    {
        if(transform.position != player.position)
        {
            Vector3 targetPosition = new Vector3(player.position.x, 
                                                 player.position.y,
                                                 transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x,
                                            minPosition.x,
                                            maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y,
                                            minPosition.y,
                                            maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);

             
        }
    }
}
