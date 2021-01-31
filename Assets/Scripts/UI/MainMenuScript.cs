using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public AudioSource source;
    public AudioClip uiYes;
    public AudioClip uiNo;

    private void Start()
    {
        
    }

    public void PressStart()
    {
        source.PlayOneShot(uiYes);
        // Start Coroutine for StartGame
        StartCoroutine(nameof(LoadGameScene));
    }

    private IEnumerator LoadGameScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PressQuit()
    {
        source.PlayOneShot(uiNo);
        StartCoroutine(nameof(QuitApplication));
    }
    private IEnumerator QuitApplication()
    {
        Debug.Log("QUIT");
        yield return new WaitForSeconds(2);
        Application.Quit();
    }
}
