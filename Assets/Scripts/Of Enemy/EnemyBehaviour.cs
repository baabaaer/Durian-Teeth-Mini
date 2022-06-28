using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public NavMeshAgent enemyAgent;
    public Transform player;
    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
    public float totalEnemyHealth, enemyHealth, healthReduction, reloadTime;
    private float timer;
    
    // The durian bullet
    public EnemyShoot enemyShoot;
    

    // Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    // Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        if(enemyShoot == null)
        {
            enemyShoot = GetComponent<EnemyShoot>();
        }
        player = GameObject.Find("Player").transform;
        enemyAgent = GetComponent<NavMeshAgent>();
        
    }

    private void Start()
    {
        
        enemyHealth = totalEnemyHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange,whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();

        

        if (enemyHealth < 0)
        {
            Destroy(gameObject);
        }
    }

    void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet) { enemyAgent.SetDestination(walkPoint); }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if(distanceToWalkPoint.magnitude < 1f) { walkPointSet = false; }

    }

    void SearchWalkPoint()
    {
        float randomX = Random.Range(-walkPointRange , walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if(Physics.Raycast(walkPoint,-transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    void ChasePlayer()
    { 
        enemyAgent.SetDestination(player.position);
    }
    void AttackPlayer()
    {
        // Need to create a unique attack system for enemy
        if(timer > reloadTime)
        {
            ThrowDurian();
        }
        

        enemyAgent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    void ThrowDurian()
    {
        // Let's make a system of aiming and attack player

        enemyShoot.Shooting();

        timer = 0.0f;
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Durian")
        {
            healthReduction = collision.collider.GetComponent<DurianFruitBehaviour>().powerAmount;
        }
        enemyHealth -= healthReduction;
        

        if (enemyHealth < 0)
        {
            Destroy(gameObject);
        }
    }
}
