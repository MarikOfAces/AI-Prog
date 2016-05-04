using UnityEngine;
using System.Collections;

public class CheckpointZone : buttonScript
{
    public Light illuminateObject;
    bool increaseLight;

    static public bool objectiveCompleted;
    static public float endGameTimer;

    static public int checkpointCount;
    public int checkpointNumber;

    public bool isLastCheckpoint;
    static public bool playerHitLastCheckpoint;

    void Start()
    {
        objectiveCompleted = false;
        endGameTimer = 5.0f;
        increaseLight = true;
        illuminateObject.intensity = 0;
        checkpointCount = 1;
        playerHitLastCheckpoint = false;
    }

    void Update()
    {
        if (checkpointCount == checkpointNumber)
        {
            illuminateCheckpointZone();
        }
        else { illuminateObject.intensity = 0; }
    }

    protected void OnTriggerEnter(Collider other)
    {
        TriggerAction();
    }

    protected override void TriggerAction()
    {
        checkpointCount++;
        if(isLastCheckpoint)
        {
            playerHitLastCheckpoint = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void illuminateCheckpointZone()
    {
        if (illuminateObject.intensity >= 8)
        {
            increaseLight = false;
        }
        else if (illuminateObject.intensity <= 0)
        {
            increaseLight = true;
        }

        if (increaseLight == true)
        {
            illuminateObject.intensity += 0.1f;

        }
        else if (increaseLight == false)
        {
            illuminateObject.intensity -= 0.1f;
        }
    }
}
