using UnityEngine;
using System.Collections;

public class rangedController : MoveTo{
    

    bool patrol = false;

    public Vector3 directionCheck;
    Vector3 raycastUp;
    Vector3 raycastDown;
    Vector3 raycastLeft;
    Vector3 raycastRight;

   
    RaycastHit hasHit;

    NavMeshAgent agent;
    Ray guardRay;



	// Use this for initialization
	void Start () {
        guardRay = new Ray(transform.position, transform.forward);
        NavMeshAgent agent = GetComponent<NavMeshAgent>();

        noiseLevel = 0;
        playerDist = 0;
        WanderRadius = 100.0f;
        lookDist = 20.0f;
        guardDmg = -5;

        agent.stoppingDistance = 10.0f;

        guardWanders = false;

        ranged = true;
        //if(PlayerSpawner.playerInst)
        //pMove = PlayerSpawner.playerInst.GetComponent<PlayerController>();


    }




}




