using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateQuests : MonoBehaviour
{
    public GameObject questLogItem;

    // Start is called before the first frame update
    void Start()
    {
        Populate();
    }

    void Populate()
    {
        GameObject newSlot;

        for (int i = 0; i < 32; i++)
        {
            newSlot = (GameObject)Instantiate(questLogItem, transform);
        }

        GameManager.Instance.UpdateQuestLog();
    }
}
