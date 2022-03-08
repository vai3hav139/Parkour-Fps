using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunFire : MonoBehaviour
{
    public Transform fpsCam;
    public float range = 20;
    public float impactForce = 150;
    public int damageAmount = 20;

    public GameObject theGun;
    public GameObject muzzleFlash;
    public AudioSource gunFire;
    public bool isFiring = false;
    public AudioSource emptySound;


    private void Fire()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.position + fpsCam.forward, fpsCam.forward, out hit, range))
        {
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            Enemy e = hit.transform.GetComponent<Enemy>();
            if (e != null)
            {
                e.TakeDamage(damageAmount);
                return;
            }

        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (GlobalAmmo.handgunAmmo < 1)
            {
                emptySound.Play();
            }
            else
            {

                if (isFiring == false)
                {
                    StartCoroutine(FiringHandgun());
                    Fire();
                }
            }
        }
    }

    IEnumerator FiringHandgun()
    {
        isFiring = true;
        GlobalAmmo.handgunAmmo -= 1;
        theGun.GetComponent<Animator>().Play("HandgunFire");
        muzzleFlash.SetActive(true);
        gunFire.Play();
        yield return new WaitForSeconds(0.05f);
        muzzleFlash.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        theGun.GetComponent<Animator>().Play("New State");
        isFiring = false;
    }
}