using UnityEngine;
using System.Collections;
public class HideZone : buttonScript {
	public bool isHiding = false;
	public Vector3 temp;
	public bool interact = false;
	public bool hideMode = false;
	bool hideAction = false;
	bool hidePressed = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		hideAction = playerMovementController.useAction;
		hidePressed = playerMovementController.usePressed;
		if (hideMode)
		{
			m_Player.gameObject.transform.position = gameObject.transform.position;
		}
	}
	
	
	
	protected override void OnTriggerStay(Collider other)
	{
		//print ("lol" + hidePressed + hideAction);
		//print ("CAN HIDE" + playerMovementController.useAction + playerMovementController.usePressed);
		if (hidePressed && !hideMode)
		{
			//Debug.Log("Action Triggerd");
			playerMovementController.detectable = false;
			temp = m_Player.gameObject.transform.position;
			m_Player.gameObject.transform.position = gameObject.transform.position;
			isHiding = true;
			Debug.Log("IS HIDING");
			//m_Player.gameObject.GetComponent<MoveTo>().noiseLevel = 0;      //Sets players noise to 0 whilst hiding
			hideMode = true;
			TriggerAction();
			//interact = true;
		}
		else if (hidePressed && hideMode)
		{
			hideMode = false;
			playerMovementController.detectable = true;
			m_Player.gameObject.transform.position = temp;
			isHiding = false;
		}
	}
	
	
	protected override void TriggerAction()
	{
		/*
        if (isHiding &&hideAction)
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
        }*/
		//if (isHiding)
		//{
		//    m_Player.gameObject.GetComponent<MoveTo>().noiseLevel = 0;      //Sets players noise to 0 whilst hiding
		//}
	}
}