using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WardrobeChange : MonoBehaviour
{
    public GameObject tooltip;
    public bool playerInRange;

    private Animator playerAnimator;
    private Text tooltipText;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GameObject.Find("Player").gameObject.GetComponent<Animator>();
        tooltipText = tooltip.transform.Find("TooltipText").gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            if (GameManager.Instance.wearingNightgown)
            {
                GameManager.Instance.wearingNightgown = false;
                playerAnimator.SetBool("wearingNightgown", false);
                GameManager.Instance.ShowTooltipWithTimeout("All dressed!");
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
        }
    }
}
