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
    //public float angulos = new Vector3(0, 0, 0);


    void Start()
    {
        navMeshAgent.destination =destinations[i].transform.position;
        //transform.localEulerAngles = navMeshAgent.destination;
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

        navMeshAgent.destination=destinations[i].position;

        //transform.localEulerAngles = navMeshAgent.destination;
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
        navMeshAgent.destination=player.transform.position;
    }
}
