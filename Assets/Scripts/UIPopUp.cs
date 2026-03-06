using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;

public class UIPopUp : MonoBehaviour

{
    public TMP_Text textElement;
    public float delayBeforeFade = 2f; //fade delay
    public float fadeDuration = 1f; //fade duration

    void Start()
    {
        StartCoroutine(FadeOutRoutine());
    }

    IEnumerator FadeOutRoutine()
    {
        yield return new WaitForSeconds(delayBeforeFade);

        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            textElement.alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            yield return null;
        }

        textElement.alpha = 0f;
        textElement.gameObject.SetActive(false); 
    }
}