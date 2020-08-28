using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// From: [Blackthornprod] https://www.youtube.com/watch?v=rhoQd6IAtDo
public class SchalaFollow : MonoBehaviour
{
    
    public float speed;
    public float stoppingDistance;
    private Animator animator;
    private Transform target;
   
    void Start() {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate ()
    {
        if(Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
            animator.SetFloat("moveX", target.position.x - transform.position.x);
            animator.SetFloat("moveY", target.position.y - transform.position.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }
    
}
