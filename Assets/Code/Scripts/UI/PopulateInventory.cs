using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateInventory : MonoBehaviour
{
    public GameObject inventorySlot;

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
            newSlot = (GameObject)Instantiate(inventorySlot, transform);
        }

        GameManager.Instance.UpdateInventory();
    }
}
