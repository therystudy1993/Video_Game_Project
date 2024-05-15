using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;


public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;

    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform pfArrowProjectile;
    [SerializeField] private Transform spawnArrowPosition;
    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;
    //Player Health Controller
    public static int playerHP = 100;
    public TextMeshProUGUI playerHPText;
    public GameObject bloodOverlay;
    public Animator animator;
    public static bool isGameOver;
    private AudioManager audioManager;
    public GameObject youDiedText;
  
    private void Awake(){
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }
    void Start(){
        isGameOver = false;
        playerHP = 100;
        youDiedText.SetActive(false);
    }
    private void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width/2f, Screen.height/2f);
        // Raycast
        Ray ray = Camera.main.ScreenPointToRay (screenCenterPoint);
        if(Physics.Raycast(ray, out RaycastHit raycastHit,999f,aimColliderLayerMask)) {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }
 
        if(starterAssetsInputs.isAiming)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotateOnMove(false);

            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;
            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime*20f);
        }
        else{
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
            thirdPersonController.SetRotateOnMove(true);
        }

        // if(starterAssetsInputs.isShooting)
        // {
        //     //Vector3 mouseWorldPosition = Vector3.zero;
        //     Vector3 aimDir = (mouseWorldPosition - spawnArrowPosition.position).normalized;
        //     Instantiate(pfArrowProjectile, spawnArrowPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
        //     starterAssetsInputs.isShooting = false;
        // }
        playerHPText.text = playerHP.ToString();
        if(isGameOver)
        {
            //display game over scene
            StartCoroutine(LoadGameOverSceneAfterDelay(5f));
            audioManager = FindObjectOfType<AudioManager>();
            if(audioManager != null)
            {
                audioManager.Stop("Explode");
            }
        }
    }

    public  IEnumerator TakeDamage(int damageAmount){
        bloodOverlay.SetActive(true);
        playerHP -=  damageAmount;
       //if playerHealth < = 0. play death animation and game over scene 
        if(playerHP <= 0)
        {
            
            isGameOver = true;
            animator.SetTrigger("dead");
            FindObjectOfType<AudioManager>().Play("ErikaDeath");
            StartCoroutine(HoldMusic(1f));
            youDiedText.SetActive(true);
            GetComponent<Collider>().enabled = false;
        }
        yield return new WaitForSeconds(1.5f);
        bloodOverlay.SetActive(false);
    }
    IEnumerator LoadGameOverSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Playground");
    }
    IEnumerator HoldMusic(float delay)
    {
        yield return new WaitForSeconds(delay);
    }
   
}
