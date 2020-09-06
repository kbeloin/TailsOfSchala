using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightgownCheck : MonoBehaviour
{
    public GameObject dialogBox;
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
            if (GameManager.Instance.wearingNightgown)
            {
                dialogueText.text = "Wouldn't want to leave without getting dressed first!";
                dialogBox.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogBox.SetActive(false);
    }
}
