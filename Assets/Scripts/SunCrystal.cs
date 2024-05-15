using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunCrystal : MonoBehaviour
{
    public GameObject directionalLight;
    public GameObject crystal;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            crystal.SetActive(false);
            AudioManager.instance.Play("Crystal_Break");
            directionalLight.transform.localEulerAngles = new Vector3(-240,0,0);
        }
    }
}
