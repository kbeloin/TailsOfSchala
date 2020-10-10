using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutfitCheck : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject nightgownBarrier;
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
            else if (!GameManager.Instance.hasBackpack)
            {
                dialogueText.text = "Better take a knapsack with! Now, where was that?";
                dialogBox.SetActive(true);
            }
            else
            {
                nightgownBarrier.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogBox.SetActive(false);
    }
}
