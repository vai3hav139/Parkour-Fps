using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDeath : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
