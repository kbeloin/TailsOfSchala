using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitTree : EnvironmentalItem
{

    private GameObject fruit;
    private Transform singleFruit;
    private GameObject ground;

    void Start()
    {
        base.Start();
        fruit = GameObject.Find("Fruit");
        ground = GameObject.Find("Ground");

    }

    public override void PlayerInteract()
    {
        UnityEngine.Debug.Log("Drop some fruit.");

        for (int i = 0; i < fruit.transform.childCount; i++)
        {
            singleFruit = fruit.transform.GetChild(i);
            singleFruit.transform.position = new Vector3(singleFruit.transform.position.x, ground.transform.position.y, singleFruit.transform.position.z);
        }
    }
}