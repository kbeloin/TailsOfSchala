using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Totally jacked from:
// https://www.youtube.com/watch?v=WchH-JCwVI8&t=3716s

public class DebugPanelUpdater : MonoBehaviour
{
    public string newText = "";

    private GameManager gm;
    private Text text;

    private void Start()
    {
        // Get the GameManager itself
        GameObject go = GameObject.Find("GameManager");
        if (go == null)
        {
            Debug.LogError("Failed to find an object named 'GameManager', oops");
            this.enabled = false;
            return;
        }

        // Get the script attached to the GameManager
        gm = go.GetComponent<GameManager>();

        text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the panel text
        newText = "";

        newText += "prevScene: " + gm.prevScene;
        newText += " / currentScene: " + gm.currentScene;
        // newText += " / health: " + gm.health;
        // newText += " / wheat: " + gm.wheat;

        text.text = newText;
    }
}
