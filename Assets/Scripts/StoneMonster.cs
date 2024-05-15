using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoneMonster : MonoBehaviour
{
    private int HP = 100;
    public Slider healthBar;
    public Animator animator;
    public GameObject projectile;
    public Transform projectilePoint;
    public static bool isWinning;
    public GameObject enemyFelled;
    public GameObject sunCrystal;
    public GameObject stoneMonster;

    void Start(){
        isWinning = false;
        enemyFelled.SetActive(false);
        sunCrystal.SetActive(false);
    }
    void Update()
    {
        healthBar.value = HP;
        if(isWinning)
        {
            //display game over scene
            StartCoroutine(LoadGameOverSceneAfterDelay(5f));
        }
    }

    public void Shoot(){
        Rigidbody rb = Instantiate(projectile,projectilePoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        //Stone monster breathes fire
        FindObjectOfType<AudioManager>().Play("Breathe_fire");
        rb.AddForce(transform.forward*30f,ForceMode.Impulse);
        rb.AddForce(transform.up*4,ForceMode.Impulse);
    }
    
    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if(HP <=0)
        {
            isWinning = true;
            //Play Death Animation
            AudioManager.instance.Play("StoneDeath");
            animator.SetTrigger("die");
            GetComponent<Collider>().enabled = false;
            //Load enemy felled text
            enemyFelled.SetActive(true);
            StartCoroutine("WaitForSec");
            //If the monster dies, we switch to other scene
            //SceneManager.LoadScene("Playground");
        }
        else
        {
            //Play Get Hit Animation
            AudioManager.instance.Play("StoneDamage");
            animator.SetTrigger("damage");
        }
    }
    IEnumerator LoadGameOverSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        //Destroy Stone Monster when it dies, replace with sun crystal
        Replace(stoneMonster,sunCrystal);
        //When enemy dies, go back to the starting point of this scene
        //SceneManager.LoadScene("Playground");
    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(3);
        Destroy(enemyFelled);
    }
    void Replace(GameObject obj1, GameObject obj2)
    {
        obj2.SetActive(true);
        Instantiate(obj2, obj1.transform.position, Quaternion.identity);
        Destroy(obj1);
    }
}
