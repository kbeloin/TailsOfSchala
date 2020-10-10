using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationOffset : MonoBehaviour
{

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();

        animator.SetFloat("offset", Random.Range(0.0f, 1.0f));

    }
}