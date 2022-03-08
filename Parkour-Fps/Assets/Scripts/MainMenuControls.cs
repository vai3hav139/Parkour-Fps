using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControls : MonoBehaviour
{
    public AudioSource clickSound;
    public GameObject fadeOut;

    public void NewGame()
    {
        StartCoroutine(NewGameRoutine());
    }

    IEnumerator NewGameRoutine()
    {
        clickSound.Play();
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(3);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void CreditButton() 
    {
        SceneManager.LoadScene(4);
    }

}