using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed;
    private Rigidbody2D rigidbody;
    private Vector3 velocity;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = Vector3.zero;

        velocity.x = Input.GetAxisRaw("Horizontal");
        velocity.y = Input.GetAxisRaw("Vertical");

        if (velocity != Vector3.zero) {
	        rigidbody.MovePosition(transform.position + velocity.normalized * speed * Time.deltaTime);

	        animator.SetFloat("moveX", velocity.x);
	        animator.SetFloat("moveY", velocity.y);
	    }
    }
}
