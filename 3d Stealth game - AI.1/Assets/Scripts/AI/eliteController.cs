using UnityEngine;
using System.Collections;

public class eliteController : MoveTo
{




    // Use this for initialization
    void Start()
    {

       // guardRay = new Ray(transform.position, transform.forward);

        noBackup = true;

        noiseLevel = 0;
        playerDist = 0;
        WanderRadius = 100.0f;
        lookDist = 15.0f;
        guardDmg = -3;
        //if(PlayerSpawner.playerInst)
        //pMove = PlayerSpawner.playerInst.GetComponent<PlayerController>();

    }

    void update()
    {
     // if (noBackup) {
		//	print ("LOLOLOLOLOL");
		//	NavMeshAgent agent = GetComponent<NavMeshAgent>();
		//	agent.destination = barracks.transform.position;
	//	}

    }

//    void Reinforcement()
//    {
//        if (transform.position == barracks.transform.position)
//        {
//            NavMeshAgent agent = GetComponent<NavMeshAgent>();
//            // elite.goal.position = barracks.transform.position;
//            Instantiate(tempGuard, new Vector3(), Quaternion.identity);
//            noBackup = false;
//        }
//
//
//    }

  /*  void guardAttack()
    {
        print("GUARD ATTACKNOW1234");
        if (goal == null)
        {
            print("GOAL IS NULL");
            isAttacking = false;
        }
        else if (noBackup)
        {
            print("no backup");
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.destination = barracks.transform.position;
        }

        else
        {
            print("backup");
            transform.LookAt(goal.position);
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.destination = goal.position;
            print("attacking player");

            if (playerDist > 5.0f)
            {
                isAttacking = false;
            }

            if ((playerDist < 4.0f) && (!isAttacking))
            {
                isAttacking = true;
                atkStart = Time.time;
            }

        }

        if (isAttacking)
        {

            atkTime = Time.time;
            if ((atkStart + 1.0f) <= atkTime)
            {
                print("Attack!");
                pMove.updatePlayerHp(guardDmg);
                print(guardDmg);
                atkStart = Time.time;
                isAttacking = false;
            }
        }

        if (attackDebug == true)
        {
            startTime = currentTime;
        }
        if (canSeePlayer())
        {

            startTime = Time.time;
            currentTime = Time.time;
        }
        else
        {
            currentTime = Time.time;
            if ((startTime + 5.0f) <= currentTime)
            {
                hasGoal = false;
            }
        }
    }*/

}




