using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceFlower : MonoBehaviour
{
    public float bouncePower = 5.0f; //how much bounce the flower has
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                if (rb.velocity.y < 0)
                    rb.velocity = new Vector2(rb.velocity.x, 0);

                rb.AddForce(Vector2.up * bouncePower, ForceMode2D.Impulse);

            }

        }

    }
}

