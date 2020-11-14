using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainsToggle : MonoBehaviour
{

    private GameObject closedLight;
    private GameObject openLight;

    public bool playerInRange;
    public bool windowOpen = false;

    public Sprite sprite1;
    public Sprite sprite2;

    private SpriteRenderer spriteRenderer;
    public Animator animator;

    void Start()
    {   
        closedLight = GameObject.Find("ClosedCurtainsLight");
        openLight = GameObject.Find("OpenCurtainsLight");
        closedLight.SetActive(false);
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        if (spriteRenderer.sprite == null) 
            spriteRenderer.sprite = sprite1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            toggleCurtains(); // call method to change sprite
        }

        if (windowOpen)
        {
            openLight.SetActive(true);
            closedLight.SetActive(false);
        }
        else
        {
            openLight.SetActive(false);
            closedLight.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    void toggleCurtains()
    {
        if (spriteRenderer.sprite == sprite1)
        {
            spriteRenderer.sprite = sprite2;
            //animator.SetBool("windowOpen", true);
            windowOpen = true;
        }
        else
        {
            spriteRenderer.sprite = sprite1;
            //animator.SetBool("windowOpen", false);
            windowOpen = false;
        }
    }
}