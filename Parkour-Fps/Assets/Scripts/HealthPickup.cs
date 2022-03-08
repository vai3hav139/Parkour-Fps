using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPickup : MonoBehaviour
{
    public AudioSource skullPickupSound;
    public GameObject pickUpDisplay;
    public GameObject firstAid;

    void OnTriggerEnter(Collider other)
    {
        if (PlayerManager.playerHP < 100)
        {
            PlayerManager.playerHP = 100;
        }
        firstAid.SetActive(false);
        skullPickupSound.Play();
        GetComponent<BoxCollider>().enabled = false;
        pickUpDisplay.SetActive(false);
        pickUpDisplay.GetComponent<Text>().text = "FIRST AID";
        pickUpDisplay.SetActive(true);
    }
}
