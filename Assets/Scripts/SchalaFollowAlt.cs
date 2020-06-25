using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// From: [Blackthornprod] https://www.youtube.com/watch?v=rhoQd6IAtDo
public class SchalaFollowAlt : MonoBehaviour
{

    public float speed;
    public float stoppingDistance;

    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("PlayerAlt").GetComponent<Transform>();

    }

    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

}
