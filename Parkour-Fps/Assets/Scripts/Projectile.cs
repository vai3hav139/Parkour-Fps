using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float radius = 3;
    public int damageAmount = 15;
    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {
            if (nearbyObject.tag == "Player")
            {
                StartCoroutine(FindObjectOfType<PlayerManager>().TakeDamage(damageAmount));
            }
        }
        this.enabled = false;
    }
}