using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    Animator animator;
    public ParticleSystem muzzleFlash;
    public float attackRefreshRate = 5f;
    public float lookRadius = 40f;
    Transform target;    
    NavMeshAgent agent;
    private float attackTimer;

    public bool isAttacking = false;

    [Header("Audio Source")]
	//Audio source used for shoot sound
	public AudioSource shootAudioSource;

    [System.Serializable]
	public class soundClips
	{
		public AudioClip shootSound;
	}
    public soundClips SoundClips;
    void Start()
    {
        animator = GetComponent<Animator>();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        shootAudioSource.clip = SoundClips.shootSound;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if( distance <= lookRadius)
        {
            GameObject thePlayer = GameObject.Find("Enemy");
            EnemyHealth player = thePlayer.GetComponent<EnemyHealth>();
            float health = player.health;
            Debug.Log(health);

            Debug.Log(player.name + " " +isAttacking);

            if(distance <= agent.stoppingDistance && health>0)
            {
                attackTimer += Time.deltaTime;

                if(CanAttack())
                {
                    Attack();
                }
                else
                {
                    animator.SetBool("shoot", false);
                }
            }
        }
    }
    private bool CanAttack()
    {
        return attackTimer >= attackRefreshRate;
    }

    private void Attack()
    {
        attackTimer = 0f;
        
        animator.SetBool("shoot", true);
        muzzleFlash.Play();

        agent.SetDestination(transform.position);
        GameObject thePlayer = GameObject.Find("Player");
        Health player = thePlayer.
        player.lowerHealth(5f);

        shootAudioSource.clip = SoundClips.shootSound;
        shootAudioSource.Play ();
    }
}

