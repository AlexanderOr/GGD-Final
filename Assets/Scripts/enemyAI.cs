using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{

    public float starttime = 5f;
    float currenttime = 0f;
    public NavMeshAgent agent;
    public AudioSource Exploision;
    public Transform Player;
    public LayerMask whatIsGround, whatIsPlayer;
    HP hp;
    public GameObject explosion;
    //patrolling
    public Vector3 walkpoint;
    bool walkpointset;
    public float walkpointrange;


    //attacking
    public float timebetweenattacks;

    public float sightrange, attackrange;

    public bool insight, inattack;

    private void Awake()
    {
        Player = GameObject.Find("First Person Player").transform;
        agent = GetComponent<NavMeshAgent>();
        Exploision = GetComponent<AudioSource>();
        hp = HP.instance;

    }
    private void Start()
    {
        currenttime = starttime;
    }

    private void Update()
    {
        //check if player is in range
        insight = Physics.CheckSphere(transform.position, sightrange, whatIsPlayer);
        inattack = Physics.CheckSphere(transform.position, attackrange, whatIsPlayer);

        currenttime -= 1 * Time.deltaTime;

        if (!insight && !inattack) Patroling();
        if (insight && !inattack) chase();
        if (insight && inattack) attack();
    }

    private void Patroling()
    {
        if (!walkpointset) searchwalkpoint();

        if (walkpointset)
            agent.SetDestination(walkpoint);

        Vector3 distancetopoint = transform.position - walkpoint;

        if (currenttime <= 0)
        {
            currenttime = starttime;
            walkpointset = false;
        }

        //walk point reached
        if (distancetopoint.magnitude < 1f)
            walkpointset = false;
      

    }
    private void searchwalkpoint()
    {
        //calculate random point in range
        float randomz = Random.Range(-walkpointrange, walkpointrange);
        float randomx = Random.Range(-walkpointrange, walkpointrange);
        walkpoint = new Vector3(transform.position.x + randomx, transform.position.y, transform.position.z + randomz);

        if (Physics.Raycast(walkpoint, -transform.up, 2f, whatIsGround))
        {
            walkpointset = true;
        }
    }





    private void chase()
    {
        agent.SetDestination(Player.position);
    }

    private void attack()
    {
        //make enemy stop moving
        agent.SetDestination(transform.position);
        transform.LookAt(Player);
        Exploision.Play();
        hp.Damage2();
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
    }

    private void Resetattack()
    {

    }


}
