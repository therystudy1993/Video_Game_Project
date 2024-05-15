using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    //This class is attached into the weapon holder
    // public int selectedWeapon = 0;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     SelectedWeapon();
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     int previousSelectedWeapon = selectedWeapon;

    //     if(Input.GetAxis("Mouse ScrollWheel") > 0f)
    //     {
    //         if(selectedWeapon >= transform.childCount -1)
    //             selectedWeapon = 0;
    //         else
    //             selectedWeapon++;
    //     }
    //     if(Input.GetAxis("Mouse ScrollWheel") < 0f)
    //     {
    //         if(selectedWeapon <= 0)
    //             selectedWeapon = transform.childCount -1;
    //         else
    //             selectedWeapon--;
    //     }

    //     if(Input.GetKey(KeyCode.Alpha1))
    //     {
    //         selectedWeapon = 0;
    //     }

    //     if(Input.GetKey(KeyCode.Alpha2) && transform.childCount >=2)
    //     {
    //         selectedWeapon = 1;
    //     }

    //     if(previousSelectedWeapon != selectedWeapon)
    //     {
    //         SelectedWeapon();
    //     }
        
    // }
    // void SelectedWeapon()
    // {
    //     // Debug.Log("This is SelectedWeapon from WeaponSwitching class!");
    //     int i = 0;
    //     foreach(Transform weapon in transform)
    //     {
    //         if(i == selectedWeapon)
    //             weapon.gameObject.SetActive(true);
    //         else
    //             weapon.gameObject.SetActive(false);
    //         i++;
    //     }
    // }
}
