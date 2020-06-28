using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed;
    private Rigidbody2D rb;
    private Vector3 velocity;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        velocity = Vector3.zero;

        velocity.x = Input.GetAxisRaw("Horizontal");
        velocity.y = Input.GetAxisRaw("Vertical");

        if (velocity != Vector3.zero) {
	        rb.MovePosition(transform.position + velocity.normalized * speed * Time.fixedDeltaTime);

	        animator.SetFloat("moveX", velocity.x);
	        animator.SetFloat("moveY", velocity.y);
					animator.SetBool("moving", true);
	    } else {
				animator.SetBool("moving", false);
			}

    }
}
