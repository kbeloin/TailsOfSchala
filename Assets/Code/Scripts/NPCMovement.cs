using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{

    public float speed;

    public bool patrol;
    public float minWaitTime;
    public float patrolMinX;
    public float patrolMinY;
    public float patrolMaxX;
    public float patrolMaxY;

    public Transform moveSpot;

    private float waitTime;
    private Animator animator;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        if (patrol)
            startPatrol();
    }

    // Update is called once per frame
    void Update()
    {
        if (patrol)
            updatePatrol();
    }


    // Initialize values for patrolling mode.
    void startPatrol()
    {
        waitTime = Random.Range(minWaitTime, minWaitTime + 10);
        moveSpot.position = new Vector2(Random.Range(patrolMinX, patrolMaxX), Random.Range(patrolMinY, patrolMaxY));
        animator.SetBool("moving", true);
    }

    // Update values for patrolling mode.
    void updatePatrol()
    {

        Vector3 temp = Vector3.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
        changeAnimation(temp - transform.position);
        transform.position = temp;

        if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            if (waitTime <= 0)
            {   

                moveSpot.position = new Vector3(Random.Range(patrolMinX, patrolMaxX), Random.Range(patrolMinY, patrolMaxY));
                animator.SetBool("moving", true);
                waitTime = Random.Range(minWaitTime, minWaitTime + 10);
            }
            else
            {
                waitTime -= Time.deltaTime;
                animator.SetBool("moving", false);

            }
        }
    }

    void changeAnimation(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                animator.SetFloat("moveX", 1);
                animator.SetFloat("moveY", 0);
            } else if (direction.x < 0)
            {
                animator.SetFloat("moveX", -1);
                animator.SetFloat("moveY", 0);
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                animator.SetFloat("moveY", 1);
                animator.SetFloat("moveX", 0);
            } else if (direction.y < 0)
            {
                animator.SetFloat("moveY", -1);
                animator.SetFloat("moveX", 0);
            }
        }
    }

}
