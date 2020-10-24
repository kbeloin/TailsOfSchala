using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivingRoomExitCheck : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject exitBarrier;
    Text dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        dialogueText = dialogBox.transform.Find("Dialogue").gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            Debug.Log(GameManager.Instance.quests[0].description);
            // if (!GameManager.Instance.quests.Contains("ThomasBirthdayBreakfast"))
            // {
            //     dialogueText.text = "I should talk to Father before I head out.";
            //     dialogBox.SetActive(true);
            // }
            // else
            // {
            //     exitBarrier.SetActive(false);
            // }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogBox.SetActive(false);
    }
}
