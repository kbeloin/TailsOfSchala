using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float walkSpeed = 6.5f;
    public float sprintSpeed = 20f;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Vector3 velocity;


    // Combat Variables
    private GameObject weapon;
    private Animator animator;
    private Animator attackAnimator;

    // Silhouette Variable
    private GameObject playerSilhouette;
    private SpriteRenderer silRenderer;

    // Dash Mechanic Variables
    private bool running = false;
    public int maxStamina = 100;
    public int stamina = 100;

    // Dialog variables
    public bool immobilized = false;

    // Scene variables
    private string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sceneName = SceneManager.GetActiveScene().name;

        weapon = GameObject.Find("Weapon");
        //attackAnimator = weapon.GetComponent<Animator>();
        playerSilhouette = GameObject.Find("PlayerSprite_Silhouette");
        silRenderer = playerSilhouette.GetComponent<SpriteRenderer>();

        if (GameManager.Instance.wearingNightgown)
        {
            animator.SetBool("wearingNightgown", true);
            animator.Play("Base Layer.Idle Nightgown");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (immobilized)
        {
            animator.SetBool("moving", false);
            running = false;
            return;
        }

        // Keeps silhouette and sprite on same animation frame.
        silRenderer.sprite = sr.sprite;

        if (running)
            moveSpeed = sprintSpeed;
        else
            moveSpeed = walkSpeed;

        velocity = Vector3.zero;

        velocity.x = Input.GetAxisRaw("Horizontal");
        velocity.y = Input.GetAxisRaw("Vertical");

        if (velocity != Vector3.zero)
        {
            rb.MovePosition(transform.position + velocity.normalized * moveSpeed * Time.fixedDeltaTime);

            animator.SetFloat("moveX", velocity.x);
            animator.SetFloat("moveY", velocity.y);
            animator.SetBool("moving", true);

        }
        else
        {
            animator.SetBool("moving", false);
        }

        // Sprint stamina drain
        if (running == true)
        {
            if (stamina >= 2)
            {
                stamina -= 10;
            }
            else
            {
                running = false;
            }
        }
        //Sprint stamina regen
        else
        {
            if (stamina < maxStamina)
            {
                stamina += 2;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameManager.Instance.ToggleInventory();
        }

        // Show/hide quest log
        if (Input.GetKeyDown(KeyCode.L))
        {
            GameManager.Instance.ToggleQuestLog();
        }

        if (GameManager.Instance.viewingInventory)
        {
            //if (Input.GetAxisRaw("Horizontal") < 0)
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (GameManager.Instance.inventoryCursor > 0) GameManager.Instance.inventoryCursor -= 1;
                GameManager.Instance.UpdateInventory();
            }

            //if (Input.GetAxisRaw("Horizontal") > 0)
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (GameManager.Instance.inventoryCursor < 31) GameManager.Instance.inventoryCursor += 1;
                GameManager.Instance.UpdateInventory();
            }

            //if (Input.GetAxisRaw("Vertical") > 0)
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (GameManager.Instance.inventoryCursor - 8 >= 0) GameManager.Instance.inventoryCursor -= 8;
                GameManager.Instance.UpdateInventory();
            }

            //if (Input.GetAxisRaw("Vertical") < 0)
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (GameManager.Instance.inventoryCursor + 8 <= 31) GameManager.Instance.inventoryCursor += 8;
                GameManager.Instance.UpdateInventory();
            }
        }

        if (GameManager.Instance.viewingQuestLog)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (GameManager.Instance.questCursor > 0) GameManager.Instance.questCursor -= 1;
                GameManager.Instance.UpdateQuestLog();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                if (GameManager.Instance.questCursor < GameManager.Instance.quests.Count - 1) GameManager.Instance.questCursor += 1;
                GameManager.Instance.UpdateQuestLog();
            }
        }

        if (immobilized)
        {
            animator.SetBool("moving", false);
            running = false;
            return;
        }

        // Attack Input
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Check to make sure we're not inside the house or bedroom
            // TODO: Check against an array of indoor scene names?
            if (sceneName != "Bedroom" && sceneName != "LivingRoom") {
              StartCoroutine(AttackCo());
            }
            // attackAnimator.SetFloat("moveX", velocity.x);
            // attackAnimator.SetFloat("moveY", velocity.y);
            // attackAnimator.SetTrigger("Attack");
        }

        // Sprint Input
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (this.stamina == maxStamina)
            {
                running = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            running = false;
        }
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(0.5f);
    }
}
