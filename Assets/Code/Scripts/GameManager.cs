using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Ink.Runtime;
using System.Collections;

public class GameManager : Singleton<GameManager>
{
    public bool wearingNightgown = true;
    public TextAsset inkAsset;
    public Story inkStory;

    InventoryItem[] inventory = new InventoryItem[0];

    Vector2 nextPosition;
    Vector3 nextCameraPosition;
    Vector2 nextDirection;

    protected GameManager() { }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        inkAsset = Resources.Load<TextAsset>("Dialogue/A1S1_Farm_Tutorial_Get_Ingredients1");
        inkStory = new Story(inkAsset.text);

        inkStory.ObserveVariable ("tooltip", (string varName, object newValue) => {
            ShowTooltip(newValue.ToString());
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
            Debug.Log(i.name);
        }
    }


    void ShowTooltip(string newText)
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

        StartCoroutine(TimeoutTooltip(tooltip));
    }

    IEnumerator TimeoutTooltip(GameObject tooltip)
    {
        yield return new WaitForSeconds(5);
        tooltip.SetActive(false);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject player = GameObject.Find("Player").gameObject;
        player.transform.position = nextPosition;
        Animator animator = player.transform.GetComponent<Animator>();
        animator.SetFloat("moveX", nextDirection.x);
        animator.SetFloat("moveY", nextDirection.y);

        Camera.main.transform.position = nextCameraPosition;
    }
}
