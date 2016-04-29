using UnityEngine;
using System.Collections;

public class eliteController : MoveTo {
  

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
        lookDist = 15.0f;
        guardDmg = -3;
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
            agent.destination = goal.position;                  //Set our path destination to the players position
            print("attacking player");

           if (playerDist > 5.0f)      //If sguard is too far from target to attack, isattacking = false
            {
                isAttacking = false;
            }

            if ((playerDist < 4.0f) && (!isAttacking)) //If guard is near player and not attacking, start attacking
            {
                isAttacking = true;
                //atkStart = Time.time;
            }
        }

        if (isAttacking)    //If guard is attacking, do attack and update player Hp every 3 seconds.
        {
            
           // atkTime = Time.time;
         
                print("Attack!");
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




