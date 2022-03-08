using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHP = 100;
    public Animator animator;
    public GameObject projectile;
    public Transform projectilePoint;
    public AudioSource enemyFire;

    public void Shoot()
    { 
        Rigidbody rb = Instantiate(projectile, projectilePoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 30f, ForceMode.Impulse);
        rb.AddForce(transform.up * 7, ForceMode.Impulse);
        enemyFire.Play();
    }

    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;

        if (enemyHP <= 0) 
        {
            
            StartCoroutine( death() );
        }
        else
        {
            animator.SetTrigger("damage");
        }
    }

    IEnumerator death() 
    {
        animator.SetTrigger("death");
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }
}
