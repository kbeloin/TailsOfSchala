using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject kitty = GameObject.Find("Kitty").gameObject;

        System.Random rnd = new System.Random();
        int index  = rnd.Next(0, 3);

        if (index == 0) {
            kitty.transform.position = new Vector3(-1.13f, .98f, 0f);
        } else if (index == 1) {
            kitty.transform.position = new Vector3(1.89f, 2.42f, 0f);
        } else if (index == 2) {
            kitty.transform.position = new Vector3(-1.13f, -2.28f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
