using UnityEngine;
using System.Collections;

public class buttonScript : customTimer
{

    public int levelToLoad;

    /*
    public GameObject text;
    public GameObject model;
    public GameObject playerCamera;
    public Color lerpedColor = Color.red;
    public float startTime;
    public float lerpRate;
    float percentage = 0.0f
    */

    protected bool m_Interractable = true;
    public GameObject m_Player = null;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<playerMovementController>())
        {
            m_Player = other.gameObject;
        }
    }

    protected virtual void OnTriggerStay(Collider other)
    {

        if (playerMovementController.useAction && m_Interractable)
        {
            TriggerAction();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<playerMovementController>())
        {
            m_Player = null;
        }
    }

    protected virtual void TriggerAction()
    {
        if (levelToLoad > 0)
        {
            Application.LoadLevel(levelToLoad);
        }

    }

    public void ToggleInterractable()
    {
        m_Interractable = !m_Interractable;
    }
}
