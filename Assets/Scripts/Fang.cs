using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fang : MonoBehaviour
{
    public int damageAmount = 20;
    public GameObject HitParticle;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log(other.name);
            //other.GetComponent<ThirdPersonShooterController>().GetBite(damageAmount);
            FindObjectOfType<AudioManager>().Play("Bite");
            Instantiate(HitParticle, new Vector3(other.transform.position.x, transform.position.y,other.transform.position.z),other.transform.rotation);
            StartCoroutine(FindObjectOfType<ThirdPersonShooterController>().TakeDamage(damageAmount));
        }
    }
}
