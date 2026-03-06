using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 respawnPos = CheckpointManager.Instance.GetCheckpoint();
            other.transform.position = respawnPos;
        }
    }
}
