using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CarrotUI : MonoBehaviour
{
    [Header("UI Reference")]
    public TextMeshProUGUI carrotText;

    private int maxCarrots;

    private void OnEnable()
    {
        CarrotEvent.OnCarrotCollected += UpdateCarrotUI;
    }

    private void OnDisable()
    {
        CarrotEvent.OnCarrotCollected -= UpdateCarrotUI;
    }

    private void Start()
    {
        maxCarrots = CheckpointManager.Instance.GetMaxCarrots();

        int current = CheckpointManager.Instance.GetCarrotCount();
        carrotText.text = current + " / " + maxCarrots;
    }

    private void UpdateCarrotUI(int carrotID, Vector3 position)
    {
        int current = CheckpointManager.Instance.GetCarrotCount();
        carrotText.text = current + " / " + maxCarrots;
    }
}
