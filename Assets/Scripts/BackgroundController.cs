using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private Vector2 startPos;
    public Vector2 parallaxEffect;   // x = horizontal, y = vertical
    private Transform cam;

    private void Start()
    {
        cam = Camera.main.transform;   
        startPos = transform.position;
    }

    private void Update()
    {
        float distX = cam.position.x * parallaxEffect.x;
        float distY = cam.position.y * parallaxEffect.y;

        transform.position = new Vector3(
            startPos.x + distX,
            startPos.y + distY,
            transform.position.z
        );
    }
}



