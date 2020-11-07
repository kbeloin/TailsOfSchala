using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThomasBirthdayBreakfast : Quest
{
    public override void Setup()
    {
        questName = "Thomas' Birthday Breakfast!";
        description = "It's your brother's birthday and Mom wants you to collect some ingredients from around the farm to make this dish extra special! She mentioned that Saffron flowers can be found near the Northern Forest, the Rosemary has been seen growing near the rocky river banks, and the Mushrooms sprout up around the Southern Pond.";
        requirements = "5 Saffron flowers, 5 Rosemary Sprigs and 5 Mushrooms";

        GameManager.Instance.itemAddDelegate += ItemAdded;
        GameManager.Instance.itemRemoveDelegate += ItemRemoved;

        GameManager.Instance.inkStory.ObserveVariable("thomas_birthday_breakfast_complete", (string varName, object newValue) => {
            if (newValue.ToString().Equals("1"))
            {
                Complete();
            }
        });
    }

    public override bool IsReadyToComplete()
    {
        return
            GameManager.Instance.GetInventoryCount("Mushroom") >= 5 &&
            GameManager.Instance.GetInventoryCount("Rosemary") >= 5 &&
            GameManager.Instance.GetInventoryCount("Saffron") >= 5;
    }

    public override void Complete()
    {
        if (!IsReadyToComplete() || isComplete) return;

        GameManager.Instance.inkStory.RemoveVariableObserver(null, "thomas_birthday_breakfast_complete");

        GameManager.Instance.itemAddDelegate -= ItemAdded;
        GameManager.Instance.itemRemoveDelegate -= ItemRemoved;

        GameManager.Instance.RemoveInventoryItem("Mushroom", 5);
        GameManager.Instance.RemoveInventoryItem("Rosemary", 5);
        GameManager.Instance.RemoveInventoryItem("Saffron", 5);

        isComplete = true;
    }

    void ItemAdded(string name)
    {
        Debug.Log("ThomasBirthdayQuest saw item added: " + name);

        if (IsReadyToComplete()) Debug.Log("ThomasBirthdayQuest is ready to complete!");

        GameManager.Instance.inkStory.variablesState["thomas_birthday_breakfast_ready"] = IsReadyToComplete();
    }

    void ItemRemoved(string name)
    {
        Debug.Log("ThomasBirthdayQuest saw item removed: " + name);

        if (IsReadyToComplete()) Debug.Log("ThomasBirthdayQuest is ready to complete!");

        GameManager.Instance.inkStory.variablesState["thomas_birthday_breakfast_ready"] = IsReadyToComplete();
    }
}
