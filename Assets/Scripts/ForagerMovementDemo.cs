using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// From: https://www.youtube.com/watch?v=plIovK-TIHc
public class ForagerMovementDemo : MonoBehaviour
{

    public Vector2 playerInput;
    Rigidbody2D rb;

    public float moveSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = playerInput.normalized * moveSpeed;
    }
}
