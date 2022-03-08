using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LifeManager : MonoBehaviour
{
    public static int lifeValue = 3;
    public GameObject lifeDisplay;

    void Update()
    {
        lifeDisplay.GetComponent<Text>().text = "" + lifeValue;
    }
}