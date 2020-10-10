using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPCOneLiner : MonoBehaviour
{
    public GameObject dialogBox;
    public Sprite npcPortrait;
    public string npcName;
    public string dialogue;
    public bool playerInRange;

    PlayerMovement playerMovement;
    GameObject portraitObject;
    GameObject nameplate;
    Text nameplateText;
    Text dialogueText;
    private AudioSource source;

    void Start()
    {
        playerMovement = GameObject.Find("Player").gameObject.GetComponent<PlayerMovement>();

        portraitObject = dialogBox.transform.Find("Portrait").gameObject;

        nameplate = dialogBox.transform.Find("Nameplate").gameObject;
        nameplateText = nameplate.transform.Find("NameLabel").gameObject.GetComponent<Text>();

        dialogueText = dialogBox.transform.Find("Dialogue").gameObject.GetComponent<Text>();

        source = GetComponent<AudioSource>();
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
        playerMovement.immobilized = true;

        dialogueText.text = dialogue;

        if (npcPortrait)
        {
            dialogueText.rectTransform.offsetMin = new Vector2(80, 16);

            portraitObject.GetComponent<Image>().sprite = npcPortrait;
            portraitObject.SetActive(true);

            nameplateText.text = npcName;
            nameplate.SetActive(true);
        }
        else
        {
            dialogueText.rectTransform.offsetMin = new Vector2(16, 16);

            portraitObject.SetActive(false);

            nameplate.SetActive(false);
        }

        dialogBox.SetActive(true);

        if (source) source.Play();
    }

    private void HideDialog()
    {
        playerMovement.immobilized = false;
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
