using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStoneMonsterUI : MonoBehaviour
{
    public GameObject stoneName;
    public GameObject stoneHealthBar;
    void Start()
    {
        stoneName.SetActive(false);
        stoneHealthBar.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            stoneName.SetActive(true);
            stoneHealthBar.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        Destroy(stoneName);
        Destroy(gameObject);
    }
}
