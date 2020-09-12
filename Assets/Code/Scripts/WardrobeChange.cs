using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WardrobeChange : MonoBehaviour
{
    public GameObject dialogBox;
    public bool playerInRange;

    private Animator playerAnimator;
    private Text dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GameObject.Find("Player").gameObject.GetComponent<Animator>();
        dialogueText = dialogBox.transform.Find("Dialogue").gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            if (GameManager.Instance.wearingNightgown)
            {
                GameManager.Instance.wearingNightgown = false;
                playerAnimator.SetBool("wearingNightgown", false);
                dialogueText.text = "You get dressed.";
                dialogBox.SetActive(true);
            }
            else
            {
                dialogBox.SetActive(false);
            }
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
            dialogBox.SetActive(false);
        }
    }
}
