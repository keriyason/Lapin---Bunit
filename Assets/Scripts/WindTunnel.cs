using System.Collections;
using UnityEngine;

public class WindTunnel : MonoBehaviour
{
    public float windSpeed = 5.0f;

    public Vector2 windDirection = Vector2.zero;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("a");
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>() ?? throw new System.Exception();
            Debug.Log(rb);
            rb.AddForce(windDirection * windSpeed, ForceMode2D.Force);

        }
    }
}
