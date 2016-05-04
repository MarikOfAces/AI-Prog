using UnityEngine;
using System.Collections;

public class MoveTo : customTimer {
    public enum State {wander, Hunt, Attack}
    public State guardAI = State.wander;


    public float noiseLevel = 0;
    public float playerDist = 0;
    public float WanderRadius = 100.0f;
    public float lookDist = 10.0f;

    public float atkTime;
    public float atkStart;

    public int guardDmg = -1;

    public bool hasGoal = false;
    public bool attackDebug;

    public bool ranged = false;


    Vector3 raycastUp;
    Vector3 raycastDown;
    Vector3 raycastLeft;
    Vector3 raycastRight;

    public Transform goal;
    RaycastHit hasHit;
    public Vector3 NewTarget;
    NavMeshAgent agent; //?
    Ray guardRay;

	public GameObject tempGuard;
	
	public GameObject tempRangedGuard;
	
	public GameObject barracks;
	
	public bool noBackup;
	public bool getBackup;
    
    public PlayerMovement pMove;

    public bool isAttacking = false;

    public bool guardWanders = true;

	void Start ()
    {
        guardRay = new Ray(transform.position, transform.forward);
        NavMeshAgent agent = GetComponent<NavMeshAgent>(); 
	}
	
	void Update () {

        raycastUp = transform.up * 0.8f + transform.forward;
        raycastDown = -transform.up * 0.8f + transform.forward;
        raycastRight = transform.right * 0.8f + transform.forward;
        raycastLeft = -transform.right * 0.8f + transform.forward;

        Debug.DrawRay(transform.position, raycastUp * lookDist, Color.blue);
        Debug.DrawRay(transform.position, raycastDown * lookDist, Color.green);
        Debug.DrawRay(transform.position, raycastLeft * lookDist, Color.yellow);
        Debug.DrawRay(transform.position, raycastRight * lookDist, Color.red);
        Debug.DrawRay(transform.position, transform.forward * lookDist, Color.black);
       
        switch (guardAI)                                                           
        {
            case State.wander:                                                 
                guardWander();
                guardGoalUpdate();

                break;
            case State.Hunt:
                guardHunt();
                guardGoalUpdate();

            break;
            case State.Attack:
                guardAttack();
                guardGoalUpdate();
               
            break;
        }
	}
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.name == "Ethan")
            {
                Destroy(other.gameObject);
            }
        }

    bool canHearPlayer ()
    {  
        playerDist = (Vector3.Distance(transform.position, goal.position));
        if (pMove.Noise >= 1)
        {
            noiseLevel = (pMove.Noise/ Mathf.Pow((playerDist/10),2));
            if (noiseLevel > playerDist)
            {
             //   print("can hear player");
                return true;
            }
            else
            {
              //  print("can't hear player");
                return false;
            }
        }
        return false;
           
    }

   public bool canSeePlayer ()
    {
		print ("GOT HERE");
        if (Physics.Raycast(transform.position, raycastUp, out hasHit, lookDist) && (hasHit.collider.name == "PlayerCube"))
        {
			//print ("GOT HERE 2");
            //if (LightDetection.playerIlluminated == true)
            //{
              //  print("Raycast up hit");
                return true;
           // }
           // else { return false; }
        }

        else if (Physics.Raycast(transform.position, raycastDown, out hasHit, lookDist) && (hasHit.collider.name == "PlayerCube"))
		{//print ("GOT HERE 2");
           // if (LightDetection.playerIlluminated == true)             
           // {
             //   print("Raycast down hit");
                return true;
           // }
          //  else { return false; }
        }

        else if (Physics.Raycast(transform.position, raycastLeft, out hasHit, lookDist) && (hasHit.collider.name == "PlayerCube"))
		{//print ("GOT HERE 2");
         //   print("Raycast left hit");
           // if (LightDetection.playerIlluminated == true)
          //  {
                return true;
          //  }
           // else { return false; }
        }

        else if (Physics.Raycast(transform.position, raycastRight, out hasHit, lookDist) && (hasHit.collider.name == "PlayerCube"))
		{print ("GOT HERE 2");
           // print("Raycast right hit");
            //if (LightDetection.playerIlluminated == true)
           // {
				print("GOT HERE 3");
                return true;
            //}
           // else { return false; }
        }

        else if (Physics.Raycast(transform.position, transform.forward, out hasHit, lookDist) && (hasHit.collider.name == "PlayerCube"))
        {
           // if (LightDetection.playerIlluminated == true)
			//{//print ("GOT HERE 2");
             //   print("Raycast forward hit");
                return true;
          //  }
         //   else { return false; }
        }

        else
        {
            return false;
        }
    }

    void guardGoalUpdate()
    {
		if (getBackup) {
			print ("nobackup");
			NavMeshAgent agent = GetComponent<NavMeshAgent>();
			agent.destination = barracks.transform.position;
			//print(Vector3.Distance(transform.position,barracks.transform.position));
			if (Vector3.Distance(transform.position,barracks.transform.position) < 1.0f)
			{
				print ("call reinforce funct");
				Reinforcement();
				getBackup = false;
			}
		}
        if (goal == null)
        {
            //print("look for goal");
            goal = pMove.transform;
        }
            if (canSeePlayer())   
            {
				print ("canSeePlayer");
				print(noBackup);
					if (noBackup)
					{
					getBackup = true;
					}
						else
						{
		                guardAI = State.Attack;
						}
            }
            else if (canHearPlayer())      
            {
                //print("canHear run");
                //guardAI = State.Hunt;
            }
    
        else                           
        {
            if (ourTimer(5))
            {
                guardAI = State.wander;
            }

        }

    }
    void guardWander()
    {
        if (hasGoal == false && guardWanders == true)      
        {
            NewTarget = Random.insideUnitSphere * WanderRadius;     
            NewTarget += transform.position;                       
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.destination = NewTarget;                               
            startTime = Time.time;
            hasGoal = true;
        }

        if (hasGoal == false && guardWanders == false)     
        {
            NewTarget = Random.insideUnitSphere * WanderRadius;     
            NewTarget += transform.position;                      
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            transform.LookAt(NewTarget);         
            startTime = Time.time;
            hasGoal = true;
        }

        currentTime = Time.time;
        if ((startTime + 5.0f) <= currentTime)
        {
            hasGoal = false;
        }

    }
      
    void guardHunt()
    {
       // print("Hunting Player");
      
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (goal == null)
            return;
        agent.SetDestination(generatePositions(generatePositions(goal.position)));
    }

    Vector3 generatePositions(Vector3 generatePosTemp)
    {
        Vector3 tempPos = Random.insideUnitSphere*10;
        tempPos += generatePosTemp;
        return tempPos;

    }
	void Reinforcement()
	{
		for (int i = 0; i < 2; i++) 
		{
			NavMeshAgent agent = GetComponent<NavMeshAgent> ();
			// elite.goal.position = barracks.transform.position;
			print ("before spawn");
			tempGuard.name = ("Reinforcement " + i);
			tempGuard.GetComponent<MoveTo>().pMove = gameObject.GetComponent<MoveTo>().pMove;
			tempGuard.GetComponent<MoveTo>().goal = goal;

			Instantiate (tempGuard, transform.position, Quaternion.identity);
			//tempGuard.GetComponentInChildren<LightDetection>().player = goal.gameObject;
			print ("after spawn");
		}
		noBackup = false;	
	}

    void guardAttack()
    {
       // print("GUARD ATTACK");
        if (goal == null)
        {
          //  print("GOAL IS NULL");
            isAttacking = false;
        }
        else
        {
			//print ("DOING OUR ELSE");
            transform.LookAt(goal.position);                    
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.destination = goal.position;                 
          //  print("attacking player");

            if (playerDist > 5.0f && ranged == false)      
            {
                isAttacking = false;
            }

            if ((playerDist < 4.0f && ranged == false) && (!isAttacking))  
            {
                isAttacking = true;
                atkStart = Time.time;
            }

            if (playerDist > 15.0f && ranged == true)
            {
                isAttacking = false;
            }

            if ((playerDist < 11.0f && ranged == true) && (!isAttacking))
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
             //   print("Attack!");
                pMove.updatePlayerHp(guardDmg);
               // print(guardDmg);
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
    }
}