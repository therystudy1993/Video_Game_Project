using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject impactEffect;
    public float radius = 3;
    public int damageAmount = 10;
    

    private void OnCollisionEnter(Collision collision)
    {
        FindObjectOfType<AudioManager>().Play("Explode");
        GameObject impact = Instantiate(impactEffect,transform.position,Quaternion.identity);
        Destroy(impact,2);
        //When enemy shoots, if the player is in the range of the effect, player gets damage
        Collider[] colliders = Physics.OverlapSphere(transform.position,radius);
        foreach(Collider nearbyObject in colliders)
        {
            if(nearbyObject.tag == "Player")
            {
                //ThirdPersonShooterController.TakeDamage(damageAmount);
                StartCoroutine(FindObjectOfType<ThirdPersonShooterController>().TakeDamage(damageAmount));
            }
        }
        //Destroy(gameObject);
        this.enabled = false; //this will not affect coroutine
    }
}
