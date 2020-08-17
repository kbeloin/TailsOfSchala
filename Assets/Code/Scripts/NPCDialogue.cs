using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Ink.Runtime;

public class NPCDialogue : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject portraitObject;
    public Sprite initialPortrait;
    public Text dialogueText;
    public bool playerInRange;
    public TextAsset inkAsset;
    Story inkStory;

    void Awake()
    {
        inkStory = new Story(inkAsset.text);
    }

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            if (dialogueBox.activeInHierarchy)
            {
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
            else
            {
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
