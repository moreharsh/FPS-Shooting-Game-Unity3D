using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Animator animator;
    public float health = 50f;
    private float maxHealth = 50f;
    bool isDead = false;
    
    void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
    }
    public void lowerHealth(float amount)
    {
        health -= amount;
        CheckEnemyHealth();
    }

    private void CheckEnemyHealth()
    {
        if(health <= 0f && !isDead)
        {
            animator.SetTrigger("die");
            gameObject.GetComponent<EnemyController>().getEnemyDead();
            Invoke(nameof(EnemyDie), 10f);
            isDead = true;
        }
    }

    private void EnemyDie()
    {
        Destroy(gameObject);
    }

}
