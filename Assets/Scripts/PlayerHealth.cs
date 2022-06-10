using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth = 100f;

    public void lowerHealthByBarrel(float amount)
    {
        playerHealth -= amount;
        GameObject thePlayer = GameObject.Find("Player");
        Health player = thePlayer.GetComponent<Health>();
        player.lowerHealth(amount);
        player.checkHealth();
    }


}
