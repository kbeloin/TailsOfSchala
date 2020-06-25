using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDialogue : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;
    public string dialogue;
    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Did you make the Text variable in your script "public" ? 
    // if so you should see an option to drag the text from the hierarchy into the script.
    // You need to make sure that the "dialog text" is also a child of the "dialog box" 
    // as turning on / off the dialog box will also turn on / off the children of the dialog box.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            if (dialogueBox.activeInHierarchy)
            {
                dialogueBox.SetActive(false);
            }
            else
            {
                dialogueBox.SetActive(true);
                dialogueText.text = dialogue;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerAlt"))
        {
            playerInRange = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerAlt"))
        {
            playerInRange = false;
            dialogueBox.SetActive(false);

        }
    }
}
