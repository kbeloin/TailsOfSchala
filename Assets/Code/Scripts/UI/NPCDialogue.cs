using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Reflection;
using Ink.Runtime;

public class NPCDialogue : MonoBehaviour
{
    public GameObject dialogBox;
    public string knotName;
    public bool playerInRange;
    public AudioSource audio;

    PlayerMovement playerMovement;
    GameObject portraitObject;
    GameObject nameplate;
    Text nameplateText;
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
    bool showingChoices;
    int currentChoice;
    string currentName;

    void Start()
    {
        playerMovement = GameObject.Find("Player").gameObject.GetComponent<PlayerMovement>();

        HideDialog();

        portraitObject = dialogBox.transform.Find("Portrait").gameObject;

        nameplate = dialogBox.transform.Find("Nameplate").gameObject;
        nameplateText = nameplate.transform.Find("NameLabel").gameObject.GetComponent<Text>();

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
            Debug.Log(GameManager.Instance.inkStory.variablesState["first_engagement"]);
            if (!dialogBox.activeInHierarchy)
            {
                ShowDialog();
            }
            else
            {
                if (showingChoices)
                {
                    GameManager.Instance.inkStory.ChooseChoiceIndex(currentChoice);

                    HideChoices();

                    if (GameManager.Instance.inkStory.canContinue)
                    {
                        StoryContinue();
                    }
                }
                else if (GameManager.Instance.inkStory.currentChoices.Count > 0)
                {
                    ShowChoices();
                }
                else if (GameManager.Instance.inkStory.canContinue)
                {
                    StoryContinue();
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
                if (currentChoice < GameManager.Instance.inkStory.currentChoices.Count - 1) currentChoice++;

                choiceOneImage.gameObject.SetActive(currentChoice == 0);
                choiceTwoImage.gameObject.SetActive(currentChoice == 1);
                choiceThreeImage.gameObject.SetActive(currentChoice == 2);
            }

            if (Input.GetKeyDown(KeyCode.W) && playerInRange)
            {
                if (currentChoice > 0) currentChoice--;

                choiceOneImage.gameObject.SetActive(currentChoice == 0);
                choiceTwoImage.gameObject.SetActive(currentChoice == 1);
                choiceThreeImage.gameObject.SetActive(currentChoice == 2);
            }
        }
    }

    private void ShowDialog()
    {
        playerMovement.immobilized = true;

        HideChoices();

        //GameManager.Instance.inkStory.ResetState();
        GameManager.Instance.inkStory.ChoosePathString(knotName);

        dialogBox.SetActive(true);

        StoryContinue();
    }

    private void StoryContinue()
    {
        dialogueText.text = GameManager.Instance.inkStory.Continue();

        portraitObject.SetActive(false);
        dialogueText.rectTransform.offsetMin = new Vector2(16, 16);
        nameplate.SetActive(false);

        foreach (string tag in GameManager.Instance.inkStory.currentTags)
        {
            if (tag.StartsWith("name"))
            {
                currentName = tag.Substring(5);

                nameplate.SetActive(true);
                nameplateText.text = currentName;

                portraitObject.SetActive(true);
                dialogueText.rectTransform.offsetMin = new Vector2(80, 16);

                portraitObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Portraits_Characters/" + currentName + "/" + currentName + "_neutral");
            }

            if (tag.StartsWith("mood"))
            {
                portraitObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Portraits_Characters/" + currentName + "/" + currentName + "_" + tag.Substring(5));
            }

            if (tag.StartsWith("sound"))
            {
                audio.clip = Resources.Load<AudioClip>("Audio/" + tag.Substring(6));
            }

            if (tag.StartsWith("quest"))
            {
                Type type = Type.GetType(tag.Substring(6));

                dynamic quest = Activator.CreateInstance(type);

                quest.Setup();

                GameManager.Instance.quests.Add(quest);
                GameManager.Instance.UpdateQuestLog();
            }

            if (tag.StartsWith("item"))
            {
                //string[] itemAttributes = tag.Substring(5).Split(',');

                //string itemName = itemAttributes[0];
                //string description = itemAttributes[1];
                //string iconName = itemAttributes[2];
                //string 

                //GameManager.Instance.AddInventoryItem()
            }
        }

        //if (GameManager.Instance.inkStory.currentTags.Count > 0)
        //{
        //    portraitObject.SetActive(true);
        //    dialogueText.rectTransform.offsetMin = new Vector2(80, 16);

        //    if (GameManager.Instance.inkStory.currentTags.Count > 1) {
        //      Debug.Log("Portraits_Characters/" + GameManager.Instance.inkStory.currentTags[0] + "/" + GameManager.Instance.inkStory.currentTags[1]);
        //      portraitObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Portraits_Characters/" + GameManager.Instance.inkStory.currentTags[0] + "/" + GameManager.Instance.inkStory.currentTags[1]);
        //    }
        //    else
        //    {
        //      Debug.Log("Portraits_Characters/" + GameManager.Instance.inkStory.currentTags[0] + "/" + GameManager.Instance.inkStory.currentTags[0] + "_neutral");
        //      portraitObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Portraits_Characters/" + GameManager.Instance.inkStory.currentTags[0] + "/" + GameManager.Instance.inkStory.currentTags[0] + "_neutral");
        //    }

        //    nameplate.SetActive(true);
        //    nameplateText.text = GameManager.Instance.inkStory.currentTags[0];
        //}
        //else
        //{
        //    portraitObject.SetActive(false);
        //    dialogueText.rectTransform.offsetMin = new Vector2(16, 16);

        //    nameplate.SetActive(false);
        //}
    }

    private void HideDialog()
    {
        playerMovement.immobilized = false;
        dialogBox.SetActive(false);
    }

    private void ShowChoices()
    {
        // Update portrait and nameplate
        nameplate.SetActive(true);
        nameplateText.text = "Kay";

        portraitObject.SetActive(true);
        dialogueText.rectTransform.offsetMin = new Vector2(80, 16);

        portraitObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Portraits_Characters/Kay/Kay_thinking");

        // Display the choices
        showingChoices = true;
        currentChoice = 0;

        dialogueText.text = "";

        for (int i = 0; i < GameManager.Instance.inkStory.currentChoices.Count; i++)
        {
            Choice choice = GameManager.Instance.inkStory.currentChoices[i];
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
            HideDialog();
        }
    }
}
