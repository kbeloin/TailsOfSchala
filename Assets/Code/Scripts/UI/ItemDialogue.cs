using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDialogue : MonoBehaviour
{
    public GameObject dialogBox;
    public Sprite initialPortrait;
    public string dialogue;
    public bool playerInRange;

    GameObject portraitObject;
    Text dialogueText;
    GameObject nameplate;

    void Start()
    {
        HideDialog();

        portraitObject = dialogBox.transform.Find("Portrait").gameObject;
        dialogueText = dialogBox.transform.Find("Dialogue").gameObject.GetComponent<Text>();
        nameplate = dialogBox.transform.Find("Nameplate").gameObject;
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
                HideDialog();
            }
        }
    }

    private void ShowDialog()
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

        dialogueText.text = dialogue;

        nameplate.SetActive(false);
        dialogBox.SetActive(true);
    }

    private void HideDialog()
    {
        dialogBox.SetActive(false);
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
