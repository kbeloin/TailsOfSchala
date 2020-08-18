using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Ink.Runtime;

public class NPCDialogue : MonoBehaviour
{
    public GameObject dialogueBox;
    public Sprite initialPortrait;
    public bool playerInRange;
    public TextAsset inkAsset;
    public TextAsset oneLiner;

    GameObject portraitObject;
    Text dialogueText;
    GameObject choiceOne;
    GameObject choiceTwo;
    GameObject choiceThree;
    Story inkStory;

    void Start()
    {
        inkStory = new Story(inkAsset.text);

        Debug.Log(dialogueBox);

        portraitObject = dialogueBox.transform.Find("Portrait").gameObject;
        dialogueText = dialogueBox.transform.Find("Text").gameObject.GetComponent<Text>();

        choiceOne = dialogueBox.transform.Find("DialogueChoice1").gameObject;
        choiceTwo = dialogueBox.transform.Find("DialogueChoice2").gameObject;
        choiceThree = dialogueBox.transform.Find("DialogueChoice3").gameObject;

        Debug.Log(portraitObject);
        Debug.Log(dialogueText);
        Debug.Log(choiceOne);
        Debug.Log(choiceTwo);
        Debug.Log(choiceThree);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            if (!dialogueBox.activeInHierarchy)
            {
                // Set up dialogue

                if (initialPortrait)
                {
                    portraitObject.SetActive(true);
                    dialogueText.rectTransform.offsetMin = new Vector2(80, 16);
                    portraitObject.GetComponent<Image>().sprite = initialPortrait;
                }
                else
                {
                    portraitObject.SetActive(false);
                    dialogueText.rectTransform.offsetMin = new Vector2(16, 16);
                }

                inkStory.ResetState();
                dialogueText.text = inkStory.Continue();

                dialogueBox.SetActive(true);
            }
            else
            {
                // Story active, continue

                if (inkStory.currentChoices.Count > 0)
                {
                    dialogueText.text = "";
                    for (int i = 0; i < inkStory.currentChoices.Count; i++)
                    {
                        Choice choice = inkStory.currentChoices[i];
                        dialogueText.text += "" + (i + 1) + ") " + choice.text + "\n";
                    }
                }
                else if (inkStory.canContinue)
                {
                    dialogueText.text = inkStory.Continue();
                }
                else
                {
                    dialogueBox.SetActive(false);
                }
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
            dialogueBox.SetActive(false);

        }
    }
}
