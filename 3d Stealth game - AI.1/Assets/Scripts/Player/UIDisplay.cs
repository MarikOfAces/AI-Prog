using UnityEngine;
using System.Collections;

public class UIDisplay : MonoBehaviour {

    public GUISkin inGame;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUI.skin = inGame;

        GUI.Label(new Rect((Screen.width / 2) - 75, 10, 140, 20), "Objects in Possession:");

        if (StealObjectScript.isObjectTaken)
        {
            //Objective Completed
            GUI.Label(new Rect((Screen.width / 2) - 62, (Screen.height / 2) - 200, 124, 20), "Objective Completed");
            GUI.Label(new Rect((Screen.width / 2) - 75, 30, 140, 20), "1x Stealable Object");
        }

    }

}
