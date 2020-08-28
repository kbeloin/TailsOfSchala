using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilhouetteMaskUpdater : MonoBehaviour
{

    private SpriteRenderer sr;
    private SpriteMask sm;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sm = GetComponent<SpriteMask>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sm.sprite != sr.sprite)
            sm.sprite = sr.sprite;
    }
}
