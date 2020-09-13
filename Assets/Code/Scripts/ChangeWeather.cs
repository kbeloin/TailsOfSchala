using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeather : MonoBehaviour
{
    public bool toSunny;
    public bool toCloudy;
    public bool toRainStorm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EnvironmentManager.Instance.sunny = toSunny;
            EnvironmentManager.Instance.cloudy = toCloudy;
            EnvironmentManager.Instance.rainStorm = toRainStorm;
        }
    }
}
