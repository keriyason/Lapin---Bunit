using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotCollectible : MonoBehaviour
{
    public int carrotID; // creates a id for each carrot 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //if the player collide w a carrot triggers event script
        {
            CarrotEvent.OnCarrotCollected?.Invoke(carrotID, transform.position);
            Destroy(gameObject);
        }
    }
}
