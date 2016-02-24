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

    Vector3 raycastUp;
    Vector3 raycastDown;
    Vector3 raycastLeft;
    Vector3 raycastRight;

    public Transform goal;
    RaycastHit hasHit;
    public Vector3 NewTarget;
    NavMeshAgent agent;
    Ray guardRay;
    
    public PlayerMovement pMove;
    public bool isAttacking = false;


	// Use this for initialization
	void Start () {
        guardRay = new Ray(transform.position, transform.forward);
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        //if(PlayerSpawner.playerInst)
            //pMove = PlayerSpawner.playerInst.GetComponent<PlayerController>();
        
    
	}
	
	// Update is called once per frame 
	void Update () {

        //raycastUp = new Vector3(0, 0.8f /* transform.forward*/, 0/*0.6f*/ /* transform.forward*/) + transform.forward;
        //raycastDown = new Vector3(0, -0.8f /* transform.forward*/, 0/*.6f*/ /* transform.forward*/) + transform.forward;
        //raycastLeft = new Vector3(0.8f /* transform.forward*/, 0, 0/*.6f*/ /* transform.forward*/) + transform.forward;
        //raycastRight = new Vector3(-0.8f /* transform.forward*/, 0, 0/*.6f*/ /* transform.forward*/) + transform.forward;

        raycastUp = transform.up * 0.8f + transform.forward;
        raycastDown = -transform.up * 0.8f + transform.forward;
        raycastRight = transform.right * 0.8f + transform.forward;
        raycastLeft = -transform.right * 0.8f + transform.forward;
        /*NraycastUp = Vector3.Scale(raycastUp, transform.localPosition);
        NraycastDown = Vector3.Scale(raycastDown, transform.localPosition);
        NraycastLeft = Vector3.Scale(raycastLeft, transform.localPosition);
        NraycastRight = Vector3.Scale(raycastRight, transform.localPosition);*/

        Debug.DrawRay(transform.position, raycastUp * lookDist, Color.blue);
        Debug.DrawRay(transform.position, raycastDown * lookDist, Color.green);
        Debug.DrawRay(transform.position, raycastLeft * lookDist, Color.yellow);
        Debug.DrawRay(transform.position, raycastRight * lookDist, Color.red);
        Debug.DrawRay(transform.position, transform.forward * lookDist, Color.black);
        //OnTriggerEnter();
        switch (guardAI)                                                            //State machine for guard AI
        {
            case State.wander:                                                      //If guard is in the 'Wander' state
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
       // noiseLevel = pMove.        //noiseLevel = playerMovement.noise;
        //print(pMove.Noise);
        //if (goal == null)
            //playerDist = noiseLevel + 1;
        //else
            //playerDist =
        //print("canHearPlayer running")
        
        playerDist = (Vector3.Distance(transform.position, goal.position));
        //print("FUqUUnity");
        //print(pMove.Noise);
        //print(playerDist);
        noiseLevel = pMove.Noise;
        if (pMove.Noise > playerDist)
        {
            print("can hear player");
            return true;
        }
        else
        {
           print("can't hear player");
            return false;
        }
           
    }

    bool canSeePlayer ()
    {
        if (Physics.Raycast(transform.position, raycastUp, out hasHit, lookDist) && (hasHit.collider.name == "PlayerCube"))
        {
            if (LightDetection.playerIlluminated == true)
            {
                print("Raycast up hit");
                // print("can see player");
                return true;
            }
            else { return false; }
        }

        else if (Physics.Raycast(transform.position, raycastDown, out hasHit, lookDist) && (hasHit.collider.name == "PlayerCube"))
        {

            //  print("can see player");
            if (LightDetection.playerIlluminated == true)             
            {
                print("Raycast down hit");
                // print("can see player");
                return true;
            }
            else { return false; }
        }

        else if (Physics.Raycast(transform.position, raycastLeft, out hasHit, lookDist) && (hasHit.collider.name == "PlayerCube"))
        {

            // print("can see player");
            print("Raycast left hit");
            if (LightDetection.playerIlluminated == true)
            {
                // print("can see player");
                return true;
            }
            else { return false; }
        }

        else if (Physics.Raycast(transform.position, raycastRight, out hasHit, lookDist) && (hasHit.collider.name == "PlayerCube"))
        {

            //  print("can see player");
            print("Raycast right hit");
            if (LightDetection.playerIlluminated == true)
            {
                // print("can see player");
                return true;
            }
            else { return false; }
        }

        else if (Physics.Raycast(transform.position, transform.forward, out hasHit, lookDist) && (hasHit.collider.name == "PlayerCube"))
        {

            // print("can see player");
            if (LightDetection.playerIlluminated == true)
            {
                print("Raycast forward hit");
                // print("can see player");
                return true;
            }
            else { return false; }
        }

        else
        {
            //  print("Cant see player");
            return false;
        }
    }

    void guardGoalUpdate()
    {
        if (goal == null) //&& PlayerSpawner.playerInst != null)
        {
            print("look for goal");
            goal = pMove.transform;
            //pMove = goal.GetComponent<pMove>();
        }
        //if (playerMovementController.detectable)
       // {
            if (canSeePlayer())             //Can we see player?
            {
                guardAI = State.Attack;
            }
            //print("canHear next");
            else if (canHearPlayer())       //Can't see player, can we hear them?
            {
                print("canHear run");
                guardAI = State.Hunt;
            }
      // }
        //print("canHear end");
        else                            //Can't see or hear player, so wander around.
        {
            if (ourTimer(5))
            {
                guardAI = State.wander;
            }

        }

    }
    void guardWander()
    {
        if (hasGoal == false)      //Can't hear or see player, Wander around. 
        {
            NewTarget = Random.insideUnitSphere * WanderRadius;     //Generate a circle around the guard of radius 'WanderRadius' and choose a random new point in that circle
            NewTarget += transform.position;                        //Add new target to guards current position  
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.destination = NewTarget;                          //Change target destination on navmesh to equal random point we just generated           
            startTime = Time.time;
            hasGoal = true;
        }
        currentTime = Time.time;
        if ((startTime + 5.0f) <= currentTime)
        {
            hasGoal = false;
        }

    }


    //public bool customTimer(int inputTime)
    //{
    //    if (!timerStarted)
    //    {     
    //        startTime = Time.time;
    //        timerStarted = true;
    //        print("timer started");
    //    }

    //    if (timerStarted)
    //    {
    //        currentTime = Time.time;
    //        if ((startTime + inputTime) <= currentTime)
    //        {
    //            print("timer done");
    //            timerStarted = false;
    //            return true;
                
    //        }
    //    }
    //    return false;
    //}
      
    void guardHunt()
    {
        print("Hunting Player");
        //NewTarget = goal.position;
        //NewTarget = new Vector3(goal.position.x + (Random.Range(-10.0f, 10.0f) * Vector3.Distance(transform.position, goal.position)), 
        //                        goal.position.y + (Random.Range(-10.0f, 10.0f) * Vector3.Distance(transform.position, goal.position)),
        //                        goal.position.z + (Random.Range(-10.0f, 10.0f) * Vector3.Distance(transform.position, goal.position)));
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (goal == null)
            return;
        agent.SetDestination(goal.position);


    }
    void guardAttack()
    {
        print("GUARD ATTACK");
        if (goal == null)
        {
            print("GOAL IS NULL");
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

            if ((playerDist < 4.0f) && (!isAttacking))  //If guard is near player and not attacking, start attacking
            {
                isAttacking = true;
                atkStart = Time.time;
            }
        }

        if (isAttacking)    //If guard is attacking, do attack and update player Hp every 3 seconds.
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




