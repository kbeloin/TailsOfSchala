using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    Vector2 viewPortSize;
    Camera cam;

    public float viewPortFactor;

    Vector3 targetPosition;
    private Vector3 currentVelocity;
    public float followDuration;
    public float maximumFollowSpeed;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        viewPortSize = (cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)) - cam.ScreenToWorldPoint(Vector2.zero)) * viewPortFactor;

        targetPosition = player.position;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, followDuration, maximumFollowSpeed);
    }

    void OnDrawGizmos()
    {
        Color c = Color.red;
        c.a = 0.3f;
        Gizmos.color = c;

        Gizmos.DrawCube(transform.position, viewPortSize);
    }
}
