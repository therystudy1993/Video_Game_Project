using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public int damageAmount = 20;
    public GameObject HitParticle;
    
    public AudioClip SwordIntoFlesh;
    // [SerializeField] private Transform vfxMonsterHit;
    // [SerializeField] private Transform vfxOtherHit;

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Stone")
        {
            Debug.Log(other.name);
            //Play sound when slashing into the monster
            AudioSource ac = GetComponent<AudioSource>();
            ac.PlayOneShot(SwordIntoFlesh);
            other.GetComponent<StoneMonster>().TakeDamage(damageAmount);
            Instantiate(HitParticle, new Vector3(other.transform.position.x, transform.position.y,other.transform.position.z),other.transform.rotation);
        }
    }
}
