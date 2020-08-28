using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GoatLogic : MonoBehaviour
{

    public bool isBaby;
    public float speed;

    private Animator animator;

    private Vector3 target;
    private Transform transform;
    private Vector2 startPosition;
    public Vector2 walkDirection;

    private bool walking;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        transform = GetComponent<Transform>();
        startPosition = transform.position;

        StartCoroutine(DecideDirection());

        target = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        walking = false;

        while (transform.position != target)
        {
            walking = true;
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.fixedDeltaTime);
            animator.SetFloat("moveX", transform.position.x);
            animator.SetFloat("moveY", transform.position.y);
            animator.SetBool("moving", true);
        }

        if (!walking)
        {
            StartCoroutine(DecideDirection());
        }
    }

    IEnumerator DecideDirection()
    {
        yield return new WaitForSeconds(2f);
        target.x = transform.position.x + 5;
        target.y = transform.position.y;
        target.z = 0;
    }

  /*  void GoatGraze()
    {
        return 0;
    }
  */
}