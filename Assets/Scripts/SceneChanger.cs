using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] string scene;

    [SerializeField] AudioSource sound;

    [SerializeField] Button button;

    private void Start()
    {
        //sound = gameObject.GetComponent<AudioSource>();
        //GetComponent<Button>().onClick.AddListener(PerformCoroutine);
        button.onClick.AddListener(PerformCoroutine);
    }
    /*
    public void ChangeScene()
    {
        sound.Play();
        SceneManager.LoadScene(scene);
    }
    */
    public void PerformCoroutine()
    {

        StartCoroutine(SoundLoadScene());
    }
    IEnumerator SoundLoadScene()
    {
        sound.PlayOneShot(sound.clip);
        yield return new WaitForSeconds(sound.clip.length);
        SceneManager.LoadScene(scene);
    }
}