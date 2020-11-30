using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    bool lightColor = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (lightColor)
        {
            collision.gameObject.GetComponent<CarPathing>().setStop(true);
        }
    }

}
