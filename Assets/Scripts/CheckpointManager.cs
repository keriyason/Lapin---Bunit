using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;

    [Header("Initial Spawn Point")]
    public Transform initialSpawnPoint;

    [Header("Carrot Settings")]
    public int maxCarrots = 10;   // editable in Inspector

    private Vector3 currentCheckpoint;
    private int carrotsCollected;
    private bool hasCheckpointSaved = false;

    private void Awake()
    {
        Instance = this;

        if (PlayerPrefs.HasKey("CarrotsCollected"))
        {
            carrotsCollected = PlayerPrefs.GetInt("CarrotsCollected");

            if (carrotsCollected > 0)
            {
                currentCheckpoint = initialSpawnPoint != null ?
                    initialSpawnPoint.position : Vector3.zero;

                carrotsCollected = 0;
                hasCheckpointSaved = true;
            }
        }
    }

    private void OnEnable()
    {
        CarrotEvent.OnCarrotCollected += SaveCheckpoint;
    }

    private void OnDisable()
    {
        CarrotEvent.OnCarrotCollected -= SaveCheckpoint;
    }

    private void SaveCheckpoint(int carrotID, Vector3 position)
    {
        carrotsCollected++;
        currentCheckpoint = position;
        hasCheckpointSaved = true;

        if (carrotsCollected >= maxCarrots)
        {
            SceneManager.LoadScene("Win");
        }

    }

    public Vector3 GetCheckpoint()
    {
        return currentCheckpoint;
    }

    public int GetCarrotCount()
    {
        return carrotsCollected;
    }

    public int GetMaxCarrots()
    {
        return maxCarrots;
    }
}

