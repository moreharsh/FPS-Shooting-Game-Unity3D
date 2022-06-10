using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject gun;
    public GameObject gunImage;
    public GameObject miniCamGun;

    public GameObject rifle;
    public GameObject rifleImage;
    public GameObject miniCamRifle;
    void Start()
    {
        gun.transform.position = rifle.transform.position;
        gun.transform.rotation = rifle.transform.rotation;
        gun.transform.eulerAngles = rifle.transform.eulerAngles;
        Cursor. visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && gun.activeSelf)
        {
            rifle.transform.position = gun.transform.position;
            rifle.transform.rotation = gun.transform.rotation;
            rifle.transform.eulerAngles = gun.transform.eulerAngles;

            gun.SetActive(false);
            miniCamGun.SetActive(false);
            gunImage.SetActive(false);
            rifle.SetActive(true);
            miniCamRifle.SetActive(true);
            rifleImage.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2) && rifle.activeSelf)
        {
            gun.transform.position = rifle.transform.position;
            gun.transform.rotation = rifle.transform.rotation;
            gun.transform.eulerAngles = rifle.transform.eulerAngles;

            gun.SetActive(true);
            miniCamGun.SetActive(true);
            gunImage.SetActive(true);
            rifle.SetActive(false);
            miniCamRifle.SetActive(false);
            rifleImage.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }
}
