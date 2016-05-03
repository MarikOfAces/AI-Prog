using UnityEngine;
using System.Collections;

public class EscortBehaviour : MonoBehaviour
{
    public float timer;
    public float timerValue;
    bool timerIsZero;

    public bool isWaitTrue;
    public Transform goal;
    public Vector3 NewTarget;
    NavMeshAgent agent; //?
    public PlayerMovement pMove;

    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = 3.5f;

        isWaitTrue = false;

        timerValue = 1.0f;
        timer = timerValue;        
        timerIsZero = false;
    }

    void Update()
    {
        NewTarget = pMove.transform.position;
        timer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Q) && (isWaitTrue == true))
        {
            isWaitTrue = false;
        }
        else if (Input.GetKeyDown(KeyCode.Q) && (isWaitTrue == false))
        {
            isWaitTrue = true;
        }


        if (isWaitTrue == false)
        {
            if ((timer <= 0) && (timerIsZero == false))
            {
                EscortFollow();
                timerIsZero = true;
            }
            if (timerIsZero == true)
            {
                timer = timerValue;
                timerIsZero = false;
            }
        }
        if (isWaitTrue == true)
        {
            EscortWait();
        }   
    }
    void EscortFollow()
    {
        goal = pMove.transform;
        transform.LookAt(goal.position);
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }
    void EscortWait()
    {
        agent.Stop();
    }
}
