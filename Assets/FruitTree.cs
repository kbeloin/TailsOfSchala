using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitTree : EnvironmentalItem
{

    private GameObject fruit;
    private GameObject ground;

    void Start()
    {
        base.Start();
        fruit = transform.Find("Fruit");
        ground = transform.Find("Ground");

    }

    public override void PlayerInteract()
    {
        UnityEngine.Debug.Log("Drop some fruit.");

        for (int i = 0; i < fruit.transform.GetChildCount(); i++)
        {
            GameObject singleFruit = fruit.transform.GetChild(i);
            singleFruit.transform.y = ground.transform.y;
        }
    }
}
