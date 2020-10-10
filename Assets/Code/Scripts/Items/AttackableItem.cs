using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;

public class AttackableItem : MonoBehaviour
{
    public bool isInteractable;
    public bool interactionSwitch;

    public bool playerInRange;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && playerInRange)
        {
            Debug.Log("Attacked this thing!");
            PlayerAttack();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            //spriteRenderer.material = highlightMaterial;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            //spriteRenderer.material = matDefault;
        }
    }

    void PlayerAttack()
    {
        interactionSwitch = !interactionSwitch;
        animator.SetBool("interactionSwitch", interactionSwitch);

        //Code for displaying dialogue goes here.

    }
}

