using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollisionBetweenCars(collision);
    }

    // Handles collision between cars
    private void HandleCollisionBetweenCars(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<CarPathing>() != null)
        {
            gameObject.GetComponent<CarPathing>().setStop(true);
        }
    }
}
