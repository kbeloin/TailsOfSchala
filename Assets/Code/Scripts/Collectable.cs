using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string itemName;
    public string description;
    public Sprite icon;
    public int weight;
    public int value;
    public bool playerInRange;

    bool collected = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange && !collected)
        {
            GameManager.Instance.ShowTooltip("Collected " + itemName + "!");
            GameManager.Instance.AddInventoryItem(itemName, description, icon, weight, value);
            GameManager.Instance.DebugInventory();
            collected = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;

            GameManager.Instance.ShowTooltip("Press E to collect");
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
