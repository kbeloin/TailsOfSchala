using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitTree : EnvironmentalItem
{

    private Transform fruit;
    private Transform singleFruit;
    private Transform ground;

    void Start()
    {
        base.Start();
        fruit = transform.Find("Fruit");
        ground = transform.Find("Ground");

    }

    public override void PlayerInteract()
    {
        UnityEngine.Debug.Log("Drop some fruit.");

        for (int i = 0; i < fruit.transform.childCount; i++)
        {
            singleFruit = fruit.transform.GetChild(i);
            singleFruit.transform.position = new Vector3(singleFruit.transform.position.x, ground.transform.position.y, singleFruit.transform.position.z);
            singleFruit.GetComponent<SpriteRenderer>().sortingOrder = 0;
            singleFruit.GetComponent<Collectable>().disabled = false;
        }

    }
}