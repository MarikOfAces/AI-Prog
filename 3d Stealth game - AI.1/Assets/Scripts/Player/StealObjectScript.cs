using UnityEngine;
using System.Collections;
public class StealObjectScript : buttonScript
{
   // bool stealPressed = false;
    static public bool isObjectTaken = false;

    public string stringToEdit = "Objective Completed";

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //stealPressed = playerMovementController.usePressed;

        if (isObjectTaken)
        {
            print("isObjectTaken");
            gameObject.SetActive(false);            
        }
    }

    protected override void OnTriggerStay(Collider other)
    {
        //if (playerMovementController.usePressed)
        //{
        //    print("stealPressed");

        //   // isObjectTaken = true;

        //}
        TriggerAction(); 
    }


    protected override void TriggerAction()
    {
        print("in Trigger Action");
        isObjectTaken = true;
    }
}