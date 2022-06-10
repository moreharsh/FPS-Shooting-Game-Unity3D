using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public TMP_Text healthText;
    public Image healthBar;
    public Image healthBarTop;
    public float health = 100f;
    public float maxHealth = 100f;
    float learpSpeed;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {

        learpSpeed = 3f * Time.deltaTime;
        
        healthText.text = health + "";
        healthText.fontSize = 36;
        healthBarFiller();
        colorChanger();
    }

    void healthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health/maxHealth, learpSpeed);
        healthBarTop.fillAmount = Mathf.Lerp(healthBarTop.fillAmount, health/maxHealth, learpSpeed * 15f * Time.deltaTime);
    }

    void colorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (health/maxHealth));
        Color healthColorTop = Color.Lerp(Color.black, Color.gray, (health/maxHealth));
        healthText.color = healthColor;
        healthBar.color = healthColor;
        healthBarTop.color = healthColorTop;
    }

    public void lowerHealth(float amount)
    {
        if(health-amount <= 0)
            health = 0;
        else
            health -= amount;
    }

    public void checkHealth()
    {
        if(health <= 0)
        {
            Debug.Log("QIUT");
            Application.Quit();
        }
    } 
}
