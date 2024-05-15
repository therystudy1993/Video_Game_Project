using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // private Rigidbody arrowRigidBody;
    public int damageAmount = 5;
    [SerializeField] private Transform vfxMonsterHit;
    [SerializeField] private Transform vfxOtherHit;
    //This class will be attached into the box_arrow prefab
    // Start is called before the first frame update
    // private void Awake()
    // {
    //     arrowRigidBody = GetComponent<Rigidbody>();
    // }
    private void Start()
    {
        // float speed = 10f;
        // arrowRigidBody.velocity = transform.forward*speed;
        Destroy(gameObject,1);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(transform.GetComponent<Rigidbody>());
        if(other.tag == "Stone")
        {
            Debug.Log("Hit monster!");
            transform.parent = other.transform;
            //Instantiate(vfxMonsterHit,transform.position, Quaternion.identity);
            other.GetComponent<StoneMonster>().TakeDamage(damageAmount);
        }
        if(other.GetComponent<StoneMonster>() != null)
        {
            //Hit Stone Monster
            Instantiate(vfxMonsterHit,transform.position, Quaternion.identity);
        }
        else{
            //Hit something else
            Instantiate(vfxOtherHit,transform.position, Quaternion.identity);
        }
    }
}
