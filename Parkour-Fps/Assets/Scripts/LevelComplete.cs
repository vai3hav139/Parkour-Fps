using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public GameObject fadeOut;
    public GameObject completePanel;
    public GameObject thePlayer;
    public GameObject levelTimer;

    void OnTriggerEnter(Collider other)
    {
        levelTimer.SetActive(false);
        StartCoroutine(CompletedFloor());
        Destroy(thePlayer);
    }

    IEnumerator CompletedFloor()
    {
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2);
        fadeOut.SetActive(false);
        completePanel.SetActive(true);
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(1);
    }
}