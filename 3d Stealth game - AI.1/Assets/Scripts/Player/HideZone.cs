using UnityEngine;
using System.Collections;

public class HideZone : buttonScript {

    public bool isHiding = false;
    public Vector3 temp;
    public bool interact = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}



    protected override void OnTriggerStay(Collider other)
    {

        if (playerMovementController.useAction && m_Interractable)
        {
            TriggerAction();
            //interact = true;
        }
    }


    protected override void TriggerAction()
    {
        if (!isHiding && interact)
        {
            interact = false;
            Debug.Log("Action Triggerd");
            playerMovementController.detectable = false;
            temp = m_Player.gameObject.transform.position;
            m_Player.gameObject.transform.position = gameObject.transform.position;
            isHiding = true;
            Debug.Log("IS HIDING");
            //m_Player.gameObject.GetComponent<MoveTo>().noiseLevel = 0;      //Sets players noise to 0 whilst hiding
        }


        if (isHiding && interact)
        {
            interact = false;
            Debug.Log("ISNT HIDING");
            playerMovementController.detectable = true;
            m_Player.gameObject.transform.position = temp;
            isHiding = false;

        }
        if (ourTimer(1))
        {
            interact = true;

        }
        //if (isHiding)
        //{
        //    m_Player.gameObject.GetComponent<MoveTo>().noiseLevel = 0;      //Sets players noise to 0 whilst hiding
        //}

    }
}
