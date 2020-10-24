using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Collectable : MonoBehaviour
{
    public string itemName;
    public string description;
    public Sprite icon;
    public int weight;
    public int value;
    public bool playerInRange;
    public bool disabled = false;

    bool collected = false;

    SpriteRenderer myRenderer;
    Light2D myLight;

    private void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        myLight = GetComponent<Light2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange && !collected && !disabled)
        {
            GameManager.Instance.ShowTooltipWithTimeout("Collected " + itemName + "!");
            GameManager.Instance.AddInventoryItem(itemName, description, icon, weight, value);
            GameManager.Instance.DebugInventory();
            myRenderer.enabled = false;
            if (myLight) {
                myLight.enabled = false;
            }
            collected = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;

            if (!collected && !disabled) GameManager.Instance.ShowTooltip("Press E to collect");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;

            if (!collected) GameManager.Instance.HideTooltip();
        }
    }
}
