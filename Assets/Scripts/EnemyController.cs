using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{   
    Animator animator;
    public float lookRadius = 40f;
    Transform target;    
    NavMeshAgent agent;
    public bool enemyDead;
    public ParticleSystem muzzleFlash;
    public float attackRefreshRate = 1.5f;
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
        enemyDead = false;

        animator = GetComponent<Animator>();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        
        shootAudioSource.clip = SoundClips.shootSound;
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if( distance <= lookRadius && !enemyDead)
        {
            animator.SetBool("run", true);
            agent.SetDestination(target.position);
            
            if(distance <= agent.stoppingDistance)
            {
                FaceTarget();
                animator.SetBool("run", false);
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
        else
        {
            animator.SetBool("run", false);
            animator.SetBool("shoot", false);
        }
    }

    public void getEnemyDead()
    {
        enemyDead = true;
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
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
        Health player = thePlayer.GetComponent<Health>();
        player.lowerHealth(5f);

        shootAudioSource.clip = SoundClips.shootSound;
        shootAudioSource.Play ();
    }
}
