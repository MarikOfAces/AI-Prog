﻿using UnityEngine;
using System.Collections;

public class playerMovementController : customTimer {

    public static bool useAction = false;
	public static bool usePressed = false;
    public bool knockout = false;
    public bool attack = false;
    public bool jump = false;
    public int movementType = 0; //0 = Walk, 1 = stealth, 2 = run

    public static bool detectable = true;
    public bool detView = detectable;
    public bool timerDone;
    public bool interactable = true;




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //KEYDOWN
        if (interactable)
        {
			if (Input.GetKeyDown(KeyCode.E) && usePressed)
            {
				//usePressed = false;
				useAction = false;
				print("TOGGLE OFF");

            }
			else if (Input.GetKeyDown(KeyCode.E) && !usePressed)
			{
				usePressed = true;
				useAction = true;
				print("TOGGLE ON");
				
			}
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {

            }
        }


            //KEYUP
            if (Input.GetKeyUp(KeyCode.E))
            {
                //usePressed = false;
            }

//        if(usePressed)
//        {
//                //interactable = false;
//                //useAction = true;
//                if (ourTimer(1))
//                {
//                    Debug.Log("Timer ended");
//                    interactable = true;
//                    useAction = false;
//                    usePressed = false;
//                }
//
//        }
//        else
//        {
//
//        }
            
	}
}