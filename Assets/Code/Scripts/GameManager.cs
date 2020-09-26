using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Ink.Runtime;

public class GameManager : Singleton<GameManager>
{
    public bool wearingNightgown = true;
    // public int health = 10;
    // public int wheat = 0;
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

        inkStory.BindExternalFunction ("multiply", (int arg1, float arg2) => {
            Debug.Log("Called the external function 'multiply'");
            return arg1 * arg2;
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


    public void ShowTooltip()
    {
        // TODO:
        // We shouldn't be relying on Ink to directly manipulate the game.
        // Instead, this should be converted to a variable observer:
        // https://github.com/inkle/ink/blob/master/Documentation/RunningYourInk.md#important-notes-on-the-usage-of-external-functions

        // Find the Tooltip object in the scene
        GameObject tooltip = GameObject.Find("Tooltip").gameObject;

        // In that Tooltip object, find the Text object
        Text tooltipText = tooltip.transform.Find("TooltipText").gameObject.GetComponent<Text>();

        // Show the tooltip!
        tooltip.SetActive(true);

        // Update the tooltip text
        tooltipText.text = "I'm a tooltip!";

        //yield return new WaitForSeconds(5);
        //tooltip.SetActive(false);
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
