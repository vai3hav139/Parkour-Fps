using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    public static int playerHP = 100;
    public GameObject healthDisplay;
    public GameObject bloodOverlay;

    public static bool isGameOver;
    void Start()
    {
        isGameOver = false;
        playerHP = 100;
    }

    void Update()
    {
        healthDisplay.GetComponent<Text>().text = "" + playerHP + "%";
        if (isGameOver)
        {
            SceneManager.LoadScene(2);
        }
    }

    public IEnumerator TakeDamage(int damageAmount)
    {
        bloodOverlay.SetActive(true);
        playerHP -= damageAmount;
        if (playerHP <= 0)
            isGameOver = true;

        yield return new WaitForSeconds(1);
        bloodOverlay.SetActive(false);

    }
}