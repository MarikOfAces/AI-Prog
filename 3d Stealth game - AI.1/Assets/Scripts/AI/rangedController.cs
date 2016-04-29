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

        guardWanders = false;
        //if(PlayerSpawner.playerInst)
        //pMove = PlayerSpawner.playerInst.GetComponent<PlayerController>();


    }

    void guardAttack()
    {
        if (goal == null)
        {
            isAttacking = false;
        }
        else
        {
            transform.LookAt(goal.position);                    //Look at our players position
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.destination = transform.position;                  //Set our path destination to the players position
            print("Archer attacking player");

           if (playerDist > 8.0f)      //If sguard is too far from target to attack, isattacking = false
            {
                isAttacking = false;
            }

            if ((playerDist < 7.0f) && (!isAttacking)) //If guard is near player and not attacking, start attacking
            {
                isAttacking = true;
                agent.Stop();
                //atkStart = Time.time;
            }
            else
            {
                isAttacking = false;
            }

        }

        if (isAttacking)    //If guard is attacking, do attack and update player Hp every 3 seconds.
        {
            
           // atkTime = Time.time;
         
                print("Ranged Attack!");
                //pMove.updatePlayerHp(guardDmg);
                //print(guardDmg);
                //atkStart = Time.time;
                isAttacking = false;
           
        }

        if (attackDebug == true)                            
        {
            startTime = currentTime;
        }
        if (canSeePlayer())                                    
        {
            //print("can see player");
            startTime = Time.time;
            currentTime = Time.time;
        }
        else
        {
            //print("cant see player");
            currentTime = Time.time;
            if ((startTime + 5.0f) <= currentTime)
            {
                hasGoal = false;
                //guardAI = State.wander;
                //print("player lost");


            }
        }
    }
}




