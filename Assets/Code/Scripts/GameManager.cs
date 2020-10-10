using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager>
{
    // Defining the state at game start
    public bool wearingNightgown = true;
    public bool hasBackpack = false;

    // Ink stories
    public TextAsset inkAsset;
    public Story inkStory;

    // Our persistent inventory
    List<InventoryItem> inventory = new List<InventoryItem>();

    // Used for the ChangeScene script
    Vector2 nextPosition;
    Vector3 nextCameraPosition;
    Vector2 nextDirection;

    protected GameManager() { }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        inkAsset = Resources.Load<TextAsset>("Dialogue/A1S1_Farm_Tutorial_Get_Ingredients1");
        inkStory = new Story(inkAsset.text);

        // Listen for a change to the "tooltip" variable in an Ink script
        // When it changes, display a tooltip with the new value
        inkStory.ObserveVariable ("tooltip", (string varName, object newValue) => {
            ShowTooltipWithTimeout(newValue.ToString());
        });

    }

    public void LoadScene(string scene, Vector2 toPosition, Vector3 toCameraPosition, Vector2 toDirection)
    {
        nextPosition = toPosition;
        nextCameraPosition = toCameraPosition;
        nextDirection = toDirection;

        SceneManager.LoadScene(scene);
    }

    public void DebugInventory()
    {
        foreach (InventoryItem i in inventory)
        {
            Debug.Log(i.itemName + " " + i.count);
        }
    }


    public void ShowTooltip(string newText)
    {
        // Find the Tooltip object in the scene
        GameObject uiCanvas = GameObject.Find("UICanvas").gameObject;
        GameObject tooltip = uiCanvas.transform.Find("Tooltip").gameObject;

        // In that Tooltip object, find the Text object
        Text tooltipText = tooltip.transform.Find("TooltipText").gameObject.GetComponent<Text>();

        // Update the tooltip text
        tooltipText.text = newText;

        // Show the tooltip!
        tooltip.SetActive(true);
    }

    public void ShowTooltipWithTimeout(string newText)
    {
        // Find the Tooltip object in the scene
        GameObject uiCanvas = GameObject.Find("UICanvas").gameObject;
        GameObject tooltip = uiCanvas.transform.Find("Tooltip").gameObject;

        // In that Tooltip object, find the Text object
        Text tooltipText = tooltip.transform.Find("TooltipText").gameObject.GetComponent<Text>();

        // Update the tooltip text
        tooltipText.text = newText;

        // Show the tooltip!
        tooltip.SetActive(true);

        // Start this special function to hide the tooltip after 5 secs
        StartCoroutine(TimeoutTooltip());
    }

    public void HideTooltip()
    {
        // Find the Tooltip object in the scene
        GameObject uiCanvas = GameObject.Find("UICanvas").gameObject;
        GameObject tooltip = uiCanvas.transform.Find("Tooltip").gameObject;

        // Hide the tooltip
        tooltip.SetActive(false);
    }

    IEnumerator TimeoutTooltip()
    {
        // Because this function has a timer in it, it's considered a
        // "coroutine" and needs to be an IEnumerator function to run.
        // We can't put coroutines in normal "void" functions.
        yield return new WaitForSeconds(5);
        HideTooltip();
    }

    public void HideDialog()
    {
        // Find the Dialog object in the scene
        GameObject uiCanvas = GameObject.Find("UICanvas").gameObject;
        GameObject dialogBox = uiCanvas.transform.Find("DialogBox").gameObject;

        // Hide the dialog box
        dialogBox.SetActive(false);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find the player in the scene
        GameObject player = GameObject.Find("Player").gameObject;

        // Move her to the position defined in ChangeScene
        player.transform.position = nextPosition;

        // Get the player's Animator
        Animator animator = player.transform.GetComponent<Animator>();

        // Update her orientation to match ChangeScene
        animator.SetFloat("moveX", nextDirection.x);
        animator.SetFloat("moveY", nextDirection.y);

        // Set the camera to the position defined in ChangeScene
        Camera.main.transform.position = nextCameraPosition;
    }

    public void AddInventoryItem(string itemName, string description, Sprite icon, int weight, int value)
    {
        InventoryItem item = new InventoryItem
        {
            itemName = itemName,
            description = description,
            icon = icon,
            weight = weight,
            value = value,
            count = 1
        };

        if (inventory.Contains(item))
        {
            inventory.Find(i => i.itemName.Equals(itemName)).count++;
        }
        else
        {
            inventory.Add(item);
        }

        UpdateInventory();

        GameObject player = GameObject.Find("Player").gameObject;
        Animator animator = player.transform.GetComponent<Animator>();

        StartCoroutine(RaiseArms(animator));
    }

    IEnumerator RaiseArms(Animator animator)
    {
        animator.SetBool("collecting", true);
        yield return new WaitForSeconds(1);
        animator.SetBool("collecting", false);
        yield return null;
    }

    public void ToggleInventory()
    {
        // Check to make sure we have the backpack first...
        if (hasBackpack) {

            // Find the Inventory layer
            GameObject uiCanvas = GameObject.Find("UICanvas").gameObject;
            GameObject inventoryView = uiCanvas.transform.Find("Inventory").gameObject;

            // Find the Backdrop object in the scene
            GameObject backdrop = uiCanvas.transform.Find("Backdrop").gameObject;

            // Hide dialog and tooltip
            HideTooltip();
            HideDialog();

            // Toggle the visibility of the backdrop based on Inventory state
            backdrop.SetActive(!inventoryView.activeInHierarchy);

            // Toggle the visibility of the inventory
            inventoryView.SetActive(!inventoryView.activeInHierarchy);
        }
    }

    public void UpdateInventory()
    {
        Debug.Log("updating inventory");

        GameObject uiCanvas = GameObject.Find("UICanvas").gameObject;
        GameObject inventoryView = uiCanvas.transform.Find("Inventory").gameObject;
        GameObject inventoryContents = inventoryView.transform.Find("InventoryContents").gameObject;

        for (int i = 0; i < 24; i++)
        {
            Image icon = inventoryContents.transform.GetChild(i).GetChild(0).GetComponent<Image>();
            Text count = inventoryContents.transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<Text>();

            if (i < inventory.Count)
            {
                icon.sprite = inventory[i].icon;
                count.text = inventory[i].count.ToString();

                icon.enabled = true;
                count.enabled = true;
            }
            else
            {
                icon.enabled = false;
                count.enabled = false;
            }
        }
    }
}
