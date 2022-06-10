using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public GameObject rifle;
    public GameObject gun;

    void Update()
    {
        if(gun.activeSelf)
            transform.position = gun.transform.position;
        else
            transform.position = rifle.transform.position;         
    }
}
