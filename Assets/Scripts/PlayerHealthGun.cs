using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthGun : MonoBehaviour
{
    public float playerHealthGun = 100f;

    public void lowerHealthByBarrel(float amount)
    {
        playerHealthGun -= amount;
        GameObject thePlayer = GameObject.Find("Player");
        Health player = thePlayer.GetComponent<Health>();
        player.lowerHealth(amount);
        player.checkHealth();
    }

}
