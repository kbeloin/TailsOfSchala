using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Vector2 viewPortSize;
    Camera cam;

    public float viewPortFactor;

    Vector3 targetPosition;
    private Vector3 currentVelocity;
    public float followDuration;
    public float maximumFollowSpeed;

    public Vector2 maxPosition;
    public Vector2 minPosition;

    public Transform player;


    Vector2 distance;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        if (player) targetPosition = player.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!player) return;

        // viewPortSize = (cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)) - cam.ScreenToWorldPoint(Vector2.zero)) * viewPortFactor;

        targetPosition.z = 0;

        distance = player.position - transform.position;
        if (Mathf.Abs(distance.x) > viewPortSize.x / 2)
        {
            targetPosition.x = player.position.x; // - (viewPortSize.x / 2 * Mathf.Sign(distance.x));
        }
        if (Mathf.Abs(distance.y) > viewPortSize.y / 2)
        {
            targetPosition.y = player.position.y; // - (viewPortSize.y / 2 * Mathf.Sign(distance.y));
        }
        // Camera Bounding
        if (transform.position != player.position)
        {
           
            targetPosition.x = Mathf.Clamp(targetPosition.x,
                                            minPosition.x,
                                            maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y,
                                            minPosition.y,
                                            maxPosition.y);


            transform.position = Vector3.Lerp(transform.position, targetPosition, 0);


        }

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition - new Vector3(0, 0, 1), ref currentVelocity, followDuration, maximumFollowSpeed);

    }

    void OnDrawGizmos()
    {
        Color c = Color.red;
        c.a = 0.3f;
        Gizmos.color = c;

        Gizmos.DrawCube(transform.position, viewPortSize);
    }
}

