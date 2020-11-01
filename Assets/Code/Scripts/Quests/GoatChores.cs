using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatChores : Quest
{
    int wheat = 0;
    int redApples = 0;
    public bool hasWateredGoats;
    public bool isComplete;



    public override void Setup()
    {
        GameManager.Instance.itemAddDelegate += ItemAdded;
        questName = "Feed the Goats";
        description = "Mother wants you to collect 10 wheat and 5 red apples and deliver them to the goat feeder. Wheat is on the farm, but you'll have to go to the orchard in town for the apples.";
        requirements = "10 Wheat and 5 Red Apples";
    }

    public override bool IsReadyToComplete()
    {
        if (wheat >= 10 && redApples >= 5 && hasWateredGoats)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void Complete()
    {
        if (!IsReadyToComplete()) return;

        GameManager.Instance.RemoveInventoryItem("Wheat", 10);
        GameManager.Instance.RemoveInventoryItem("Red Apple", 5);

        isComplete = true;
    }

    void ItemAdded(string name)
    {
        Debug.Log("GoatChores saw item added: " + name);

        if (name.Equals("Wheat")) wheat += 1;
        if (name.Equals("Red Apple")) redApples += 1;

        if (IsReadyToComplete()) Debug.Log("ThomasBirthdayQuest is ready to complete!");
    }
}
