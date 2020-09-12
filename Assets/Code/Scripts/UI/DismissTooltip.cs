using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DismissTooltip : MonoBehaviour
{
    public GameObject tooltip;
    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            if (tooltip.activeInHierarchy)
            {
                HideDialog();
            }
        }
    }

    private void HideDialog()
    {
        tooltip.SetActive(false);
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
