using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int scoreValue = 0;
    public GameObject scoreDisplay;
    public GameObject finalScore;

    void Update()
    {
        scoreDisplay.GetComponent<Text>().text = "" + scoreValue;
        finalScore.GetComponent<Text>().text = "" + scoreValue;
    }
}