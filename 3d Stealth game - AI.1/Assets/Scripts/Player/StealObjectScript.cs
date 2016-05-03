using UnityEngine;
using System.Collections;
public class StealObjectScript : buttonScript
{
   // bool stealPressed = false;
    static public bool isObjectTaken = false;
    public Light illuminateObject;
    bool increaseLight;
    void Start()
    {
        increaseLight = true;
    }

    // Update is called once per frame
    void Update()
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