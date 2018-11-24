using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class UnitController : MonoBehaviour
{
    //State Machine
    enum PlayerState
    {
        Idle,
        Run,
        Walking,
        WalkingTowardTarget,
        Attack1,
        Attack2,
        Die,
        Dead,
    }
    [SerializeField]
    PlayerState playerState;
    [SerializeField]
    GameObject target;
    [SerializeField]
    Transform firingRing;
    AudioSource footSteps;

    //Other variables
    private Animator anim;
    private NavMeshAgent agent;
    private Ray ray;
    private RaycastHit hit;
    bool attacking1, attacking2;

    [SerializeField]
    GameObject magicrRing;
    [SerializeField]
    GameObject mainCanvas;
    AudioSource spellCast1;
    void Start ()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        attacking1 = false;
        attacking2 = false;
        firingRing = GameObject.FindGameObjectWithTag("Ring").transform;
        AudioSource[] audios = GetComponentsInChildren<AudioSource>();
        print(audios.Length + " audios");
        footSteps = audios[0];
        //spellCast1 = audios[1];
        mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas");
    }
	

	void Update ()
    {
		if(Input.GetMouseButton(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 500))
            {
                //print(hit.transform.tag);
                Transform temp = hit.transform.root;
                if (temp.CompareTag("Enemy"))
                {
                    if(temp.gameObject != target && target != null) //selecting a different target and previous not null
                    {
                        target.GetComponent<EnemyController>().Targeted(false);
                        DeactivateTargetPanel();
                    }
                    target= hit.transform.root.gameObject;
                    Debug.Log("Enemy Targeted");
                    target.GetComponent<EnemyController>().Targeted(true);
                    ActivateTargetPanel();
                }
                else
                {
                    if(target != null)
                    {
                        target.GetComponent<EnemyController>().Targeted(false);
                        DeactivateTargetPanel();
                    }
                    target = null;
                    agent.destination = hit.point;
                    agent.isStopped = false;
                    Run();
                }
            }
        }
        if (Input.GetKey(KeyCode.F1) && !attacking1 && target != null)
        {
            attacking1 = true;
            Attack1();
        }
        if (Input.GetKey(KeyCode.F2) && !attacking2)
        {
            attacking2 = true;
            Attack2();
        }
        switch (playerState)
        {
            case PlayerState.Idle:
                break;

            case PlayerState.Run:
                if(!footSteps.isPlaying)
                {
                    footSteps.Play();
                }
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    if (!agent.hasPath || Mathf.Abs(agent.velocity.sqrMagnitude) < float.Epsilon)
                    {
                        agent.isStopped = true;
                        Idle();
                    }
                }
                anim.PlayInFixedTime("Run");
                break;

            case PlayerState.Walking:
                break;

            case PlayerState.WalkingTowardTarget:
                break;

            case PlayerState.Attack1:
                transform.LookAt(target.GetComponentInChildren<Collider>().bounds.center);
                if(Input.GetKeyUp(KeyCode.F1))
                {
                    attacking1 = false;
                    Idle();
                }
                
                break;

            case PlayerState.Attack2:
                if (Input.GetKeyUp(KeyCode.F2))
                {
                    attacking2 = false;
                    Idle();
                }
                break;

            case PlayerState.Die:
                break;

            case PlayerState.Dead:
                break;

            default:
                break;
        }

    }

    void Run()
    {
        anim.SetBool("Run", true);
        anim.SetBool("Idle", false);
        anim.SetBool("Attack1", false);
        anim.SetBool("Attack2", false);
        playerState = PlayerState.Run;
    }

    void Idle()
    {
        footSteps.Stop();
        agent.isStopped = true;
        anim.SetBool("Run", false);
        anim.SetBool("Idle", true);
        anim.SetBool("Attack1", false);
        anim.SetBool("Attack2", false);
        playerState = PlayerState.Idle;
    }

    void Attack1()
    {
        //spellCast1.Play(20000);
        footSteps.Stop();
        agent.isStopped = true;
        anim.SetBool("Run", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Attack1", true);
        anim.SetBool("Attack2", false);
        playerState = PlayerState.Attack1;
    }

    void Attack2()
    {
        footSteps.Stop();
        agent.isStopped = true;
        anim.SetBool("Run", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Attack1", false);
        anim.SetBool("Attack2", true);
        playerState = PlayerState.Attack2;
        GameObject temp = Instantiate(magicrRing, transform.position, Quaternion.Euler(-90,0,0));
        temp.transform.parent = transform;
    }

    public GameObject GetTarget()
    {
        return target;
    }

    public void ActivateTargetPanel()
    {
        GameObject thisTarget = GetTarget();
        if(thisTarget != null)
        {
            mainCanvas.GetComponent<MainCanvasScript>().ActivateTargetPanel(thisTarget);
        }
    }

    public void DeactivateTargetPanel()
    {
        mainCanvas.GetComponent<MainCanvasScript>().DeactivateTargetPanel();
    }
    
}
