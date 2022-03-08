using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkullPickup : MonoBehaviour
{
    public GameObject scoreSkull;
    public AudioSource skullPickupSound;
    public GameObject pickUpDisplay;

    void OnTriggerEnter(Collider other)
    {
        scoreSkull.SetActive(false);
        ScoreManager.scoreValue += 10;
        skullPickupSound.Play();
        GetComponent<BoxCollider>().enabled = false;
        pickUpDisplay.SetActive(false);
        pickUpDisplay.GetComponent<Text>().text = "SCORE SKULL";
        pickUpDisplay.SetActive(true);
    }
}
