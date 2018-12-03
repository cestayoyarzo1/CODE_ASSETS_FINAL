using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    //[SerializeField]
    //Image healthBar;
    [SerializeField]
    float health, maxHealth;
    [SerializeField]
    float idleTime, timer, randomRadius;
    [SerializeField]
    GameObject targeted;
    [SerializeField]
    float attackDistance, chaseDistance;
    [SerializeField]
    GameObject prevTarget, currentTarget;
    [SerializeField]
    float walkingSpeed, runningSpeed;

    enum MonsterState
    {
        Idle,
        MovingRandom,
        WalkingTowards,
        RunningTowards,
        Attacking,
        Dying,
        Dead
    }

    MonsterState myState, prevState;
    //Private variables
    private Animator anim;
    private NavMeshAgent agent;

    void Start ()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        idleTime = Random.Range(2.0f, 10.0f);
        timer = 0f;
        health = maxHealth;
    }
	

	void Update ()
    {
        switch (myState)
        {
            case MonsterState.Idle:
                if(timer> idleTime)
                {
                    timer = 0f;
                    idleTime = Random.Range(2.0f, 10.0f);
                    prevState = myState;
                    myState = MonsterState.MovingRandom;
                }
                else
                {
                    timer += Time.deltaTime;
                }
                break;

            case MonsterState.MovingRandom:
                Vector3 randomDest = RandomNavmeshLocation(randomRadius);
                prevState = myState;
                Walk(randomDest);
                break;

            case MonsterState.WalkingTowards:

                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    if (!agent.hasPath || Mathf.Abs(agent.velocity.sqrMagnitude) < float.Epsilon)
                    {
                        if(prevState == MonsterState.MovingRandom)
                        {
                            agent.isStopped = true;
                            Idle();
                        }
                    }
                }
                break;

            case MonsterState.RunningTowards:
                if(currentTarget != null && agent.remainingDistance <= attackDistance)
                {
                   Attack();
                }
                break;
            
            case MonsterState.Attacking:
                if(Vector3.Distance(currentTarget.transform.position, transform.position) > chaseDistance)
                {
                    Chase();
                }
                break;

            case MonsterState.Dying:
                break;

            case MonsterState.Dead:
                break;

            default:
                break;
        }
    }

    void Idle()
    {
        agent.isStopped = true;
        anim.SetBool("Idle", true);
        anim.SetBool("Walk", false);
        anim.SetBool("Run", false);
        anim.SetBool("Attack", false);
        anim.SetBool("Die", false);
        agent.isStopped = true;
        myState = MonsterState.Idle;
    }

    void Walk(Vector3 dest)
    {
        anim.SetBool("Walk", true);
        anim.SetBool("Idle", false);
        anim.SetBool("Run", false);
        anim.SetBool("Attack", false);
        anim.SetBool("Die", false);
        agent.SetDestination(dest);
        agent.isStopped = false;
        myState = MonsterState.WalkingTowards;
    }
    void Run(Vector3 dest)
    {
        anim.SetBool("Run", true);
        anim.SetBool("Idle", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Attack", false);
        anim.SetBool("Die", false);
        agent.SetDestination(dest);
        agent.isStopped = false;
        myState = MonsterState.RunningTowards;
    }

    void Attack()
    {
        anim.SetBool("Attack", true);
        anim.SetBool("Idle", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Run", false);
        anim.SetBool("Die", false);
        agent.isStopped = true;
        myState = MonsterState.Attacking;
    }

    void Die()
    {
        anim.SetBool("Die", true);
        anim.SetBool("Attack", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Run", false);
        agent.isStopped = true;
        myState = MonsterState.Dying;
    }

    void Chase()
    {
        anim.SetBool("Die", false);
        anim.SetBool("Attack", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Run", true);
        agent.SetDestination(currentTarget.transform.position);
        agent.isStopped = false;
        agent.speed = runningSpeed;
        myState = MonsterState.RunningTowards;
    }

    Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    public void Targeted(bool set)
    {
        targeted.SetActive(set);
    }

    public void ActivatePanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void UpdateField()
    {

    }
    public void TakeDamage(float damage, GameObject sender)
    {
        health -= damage;
        Mathf.Clamp(health, 0, health);
        GetComponent<StatsController>().UpdateHealth(health);
        if(health <= 0)
        {
            Die();
        }
        currentTarget = sender;
        Chase();
    }
}
