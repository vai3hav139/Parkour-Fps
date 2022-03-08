using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecycleLevel : MonoBehaviour
{

    public GameObject gameOver;

    void Start()
    {
        LifeManager.lifeValue -= 1;
        if (LifeManager.lifeValue == 0)
        {
            gameOver.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(3);
        }
    }

}