using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Ink.Runtime;

public class NPCDialogue : MonoBehaviour
{
    public Sprite initialPortrait;
    public bool playerInRange;
    public TextAsset inkAsset;
    public TextAsset oneLiner;
    public GameObject dialogBox;

    PlayerMovement playerMovement;
    GameObject portraitObject;
    Text dialogueText;
    GameObject choiceOne;
    GameObject choiceTwo;
    GameObject choiceThree;
    Text choiceOneText;
    Text choiceTwoText;
    Text choiceThreeText;
    Image choiceOneImage;
    Image choiceTwoImage;
    Image choiceThreeImage;
    Story inkStory;
    bool showingChoices;
    int currentChoice;

    void Start()
    {
        playerMovement = GameObject.Find("Player").gameObject.GetComponent<PlayerMovement>();

        inkStory = new Story(inkAsset.text);

        Debug.Log(dialogBox);

        portraitObject = dialogBox.transform.Find("Portrait").gameObject;
        dialogueText = dialogBox.transform.Find("Dialogue").gameObject.GetComponent<Text>();

        choiceOne = dialogBox.transform.Find("ChoiceOne").gameObject;
        choiceTwo = dialogBox.transform.Find("ChoiceTwo").gameObject;
        choiceThree = dialogBox.transform.Find("ChoiceThree").gameObject;

        choiceOneText = choiceOne.transform.Find("Text").gameObject.GetComponent<Text>();
        choiceTwoText = choiceTwo.transform.Find("Text").gameObject.GetComponent<Text>();
        choiceThreeText = choiceThree.transform.Find("Text").gameObject.GetComponent<Text>();

        choiceOneImage = choiceOne.transform.Find("Image").gameObject.GetComponent<Image>();
        choiceTwoImage = choiceTwo.transform.Find("Image").gameObject.GetComponent<Image>();
        choiceThreeImage = choiceThree.transform.Find("Image").gameObject.GetComponent<Image>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            if (!dialogBox.activeInHierarchy)
            {
                ShowDialog();
            }
            else
            {
                if (showingChoices)
                {
                    inkStory.ChooseChoiceIndex(currentChoice);

                    HideChoices();

                    if (inkStory.canContinue)
                    {
                        dialogueText.text = inkStory.Continue();
                    }
                }
                else if (inkStory.currentChoices.Count > 0)
                {
                    ShowChoices();
                }
                else if (inkStory.canContinue)
                {
                    dialogueText.text = inkStory.Continue();
                    if (inkStory.currentTags.Count > 0)
                    {
                        Debug.Log(inkStory.currentTags[0].ToLower() + "_neutral.png");
                        portraitObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(inkStory.currentTags[0].ToLower() + "_neutral");
                    }
                }
                else
                {
                    HideDialog();
                }
            }
        }

        if (showingChoices)
        {
            if (Input.GetKeyDown(KeyCode.S) && playerInRange)
            {
                if (currentChoice < inkStory.currentChoices.Count - 1) currentChoice++;
            }

            if (Input.GetKeyDown(KeyCode.W) && playerInRange)
            {
                if (currentChoice > 0) currentChoice--;
            }

            choiceOneImage.gameObject.SetActive(currentChoice == 0);
            choiceTwoImage.gameObject.SetActive(currentChoice == 1);
            choiceThreeImage.gameObject.SetActive(currentChoice == 2);
        }
    }

    private void ShowDialog()
    {
        playerMovement.inDialogue = true;

        HideChoices();

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

        dialogBox.SetActive(true);
    }

    private void HideDialog()
    {
        playerMovement.inDialogue = false;
        dialogBox.SetActive(false);
    }

    private void ShowChoices()
    {
        showingChoices = true;
        currentChoice = 0;

        dialogueText.text = "";

        for (int i = 0; i < inkStory.currentChoices.Count; i++)
        {
            Choice choice = inkStory.currentChoices[i];
            switch (i)
            {
                case 0:
                    choiceOne.SetActive(true);
                    choiceOneText.text = choice.text;
                    break;
                case 1:
                    choiceTwo.SetActive(true);
                    choiceTwoText.text = choice.text;
                    break;
                case 2:
                    choiceThree.SetActive(true);
                    choiceThreeText.text = choice.text;
                    break;
            }
        }

        choiceOneImage.gameObject.SetActive(currentChoice == 0);
        choiceTwoImage.gameObject.SetActive(currentChoice == 1);
        choiceThreeImage.gameObject.SetActive(currentChoice == 2);
    }

    private void HideChoices()
    {
        showingChoices = false;

        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);
        choiceThree.SetActive(false);
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
