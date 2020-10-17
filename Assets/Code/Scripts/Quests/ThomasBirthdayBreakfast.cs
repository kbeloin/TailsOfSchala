using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThomasBirthdayBreakfast : Quest
{
    int freshMushrooms = 0;
    int rosemarySprigs = 0;
    int saffronFlowers = 0;
    public bool isComplete;

    public override void Setup()
    {
        GameManager.Instance.itemAddDelegate += ItemAdded;
    }

    public override bool IsReadyToComplete()
    {
        if (freshMushrooms >= 5 && rosemarySprigs >= 5 && saffronFlowers >= 5)
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

        GameManager.Instance.RemoveInventoryItem("Mushroom", 5);
        GameManager.Instance.RemoveInventoryItem("Rosemary", 5);
        GameManager.Instance.RemoveInventoryItem("Saffron", 5);

        isComplete = true;
    }

    void ItemAdded(string name)
    {
        Debug.Log("ThomasBirthdayQuest saw item added: " + name);

        if (name.Equals("Mushroom")) freshMushrooms += 1;
        if (name.Equals("Rosemary")) rosemarySprigs += 1;
        if (name.Equals("Saffron")) saffronFlowers += 1;

        if (IsReadyToComplete()) Debug.Log("ThomasBirthdayQuest is ready to complete!");
    }
}
