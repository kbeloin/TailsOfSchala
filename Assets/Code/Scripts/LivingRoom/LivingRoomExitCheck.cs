using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivingRoomExitCheck : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject exitBarrier;
    Text dialogueText;

    GameObject portraitObject;
    GameObject nameplate;

    // Start is called before the first frame update
    void Start()
    {
        dialogueText = dialogBox.transform.Find("Dialogue").gameObject.GetComponent<Text>();
        portraitObject = dialogBox.transform.Find("Portrait").gameObject;
        nameplate = dialogBox.transform.Find("Nameplate").gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameManager.Instance.quests.Find(q => q.questName == "Thomas' Birthday Breakfast!") == null)
            {
                dialogueText.text = "I should talk to Father before I head out.";
                portraitObject.SetActive(false);
                dialogueText.rectTransform.offsetMin = new Vector2(16, 16);
                nameplate.SetActive(false);
                dialogBox.SetActive(true);
            }
            else
            {
                exitBarrier.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogBox.SetActive(false);
    }
}
