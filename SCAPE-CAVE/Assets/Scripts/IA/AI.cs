using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;

    public Transform[] destinations;

    public float distanceToFollowPath=2;

    private int i=0;

    [Header("---------FollowPlayer----")]
    public bool followPlayer;

    private GameObject player;

    private float distanceToPlayer;

    public float distanceToFollowPlayer =10;
    private float direction ;

    void Start()
    {
        Vector3 moveDirection = (destinations[i].position - transform.position).normalized;

        // Invierte la dirección de movimiento para hacer que el personaje mire en la dirección opuesta
        Vector3 oppositeDirection = -moveDirection;

        // Orienta el personaje hacia la dirección opuesta
        transform.LookAt(transform.position + oppositeDirection);

        // Establece la dirección de movimiento del personaje

        navMeshAgent.destination = destinations[i].transform.position;
        //navMeshAgent.destination =destinations[i].transform.position;


        player = FindObjectOfType<PlayerMovement>().gameObject;
        
    }

    void Update()
    {
        distanceToPlayer=Vector3.Distance(transform.position, player.transform.position);
        if(distanceToPlayer <= distanceToFollowPlayer && followPlayer)
        {
            FollowPlayer();
        }
        else{
            
            EnemyPath();
        }

    }

    public void EnemyPath()
    {

        Vector3 moveDirection = (destinations[i].position - transform.position).normalized;

        // Invierte la dirección de movimiento para hacer que el personaje mire en la dirección opuesta
        Vector3 oppositeDirection = -moveDirection;

        // Orienta el personaje hacia la dirección opuesta
        transform.LookAt(transform.position + oppositeDirection);

        // Establece la dirección de movimiento del personaje
        navMeshAgent.destination = destinations[i].transform.position;

        if (Vector3.Distance(transform.position, destinations[i].position) <= distanceToFollowPath){
            Debug.Log("Localizacion: "+i);

            if(destinations[i]!= destinations[destinations.Length -1])
            {     
                i++;
            }
            else
            {
                i=0;
            }
        }
    }

    public void FollowPlayer(){

        Vector3 moveDirection = (player.transform.position - transform.position).normalized;

        // Invierte la dirección de movimiento para hacer que el personaje mire en la dirección opuesta
        Vector3 oppositeDirection = -moveDirection;

        // Orienta el personaje hacia la dirección opuesta
        transform.LookAt(transform.position + oppositeDirection);

        // Establece la dirección de movimiento del personaje

        navMeshAgent.destination=player.transform.position;

    }
}
