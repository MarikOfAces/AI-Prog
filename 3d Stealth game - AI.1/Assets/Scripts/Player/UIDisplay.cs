using UnityEngine;
using System.Collections;

public class UIDisplay : MonoBehaviour {

    public GUISkin inGame;
    public GUISkin inControls;

    private bool pauseEnabled;
    private bool isMain;
    private bool isControls;

    // Use this for initialization
    void Start ()
    {
        ////////////////
        // IN-GAME PAUSE
        ////////////////
        pauseEnabled = false;
        isMain = true;
        isControls = false;
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update ()
    {
        ////////////////
        // IN-GAME PAUSE
        ////////////////
        if (Input.GetButtonUp("Pause"))
        {
            if (pauseEnabled == true)
            {
                pauseEnabled = false;
                Time.timeScale = 1;
                AudioListener.pause = false;
            }

            else if (pauseEnabled == false)
            {
                pauseEnabled = true;
                AudioListener.pause = true;
                Time.timeScale = 0;
            }
        }
    }

    void OnGUI()
    {
        GUI.skin = inGame;

        ////////////////
        // IN-GAME PAUSE
        ////////////////
        if (pauseEnabled == true)
        {
            if (isMain == true)
            {
                GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 150, 250, 300), "PAUSED");

                if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 250, 40), "Resume"))
                {
                    pauseEnabled = false;
                    Time.timeScale = 1;
                }

                if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 250, 40), "Restart Level"))
                {
                    Application.LoadLevel(Application.loadedLevel);
                }

                if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2, 250, 40), "View Controls"))
                {
                    isMain = false;
                    isControls = true;
                }

                if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 50, 250, 40), "Return to Main Menu"))
                {
                    Application.LoadLevel(0);
                }

                if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 100, 250, 40), "Quit Application"))
                {
                    Application.Quit();
                }
            }

            if (isControls == true)
            {
                GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "VIEW CONTROLS");

                if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 300, 250, 40), "Back"))
                {
                    isControls = false;
                    isMain = true;
                }

                GUI.skin = inControls;

                GUI.Box(new Rect((Screen.width / 2) - 400, (Screen.height / 2) - 300, 200, 70), "MOVEMENT:");
                GUI.Label(new Rect((Screen.width / 2) - 350, (Screen.height / 2) - 250, 200, 20), "W/S/A/D");

                GUI.Box(new Rect((Screen.width / 2) - 400, (Screen.height / 2) - 200, 200, 70), "JUMP:");
                GUI.Label(new Rect((Screen.width / 2) - 350, (Screen.height / 2) - 150, 200, 20), "Space Bar");


                GUI.Box(new Rect((Screen.width / 2) + 200, (Screen.height / 2) - 200, 200, 70), "ESCORT FOLLOW/WAIT:");
                GUI.Label(new Rect((Screen.width / 2) + 275, (Screen.height / 2) - 150, 200, 20), "Q");

                GUI.Box(new Rect((Screen.width / 2) + 200, (Screen.height / 2) - 300, 200, 70), "INTERACT:");
                GUI.Label(new Rect((Screen.width / 2) + 275, (Screen.height / 2) - 250, 200, 20), "E");


                GUI.Box(new Rect((Screen.width / 2) - 225, (Screen.height / 2), 200, 70), "MELEE ATTACK:");
                GUI.Label(new Rect((Screen.width / 2) - 175, (Screen.height / 2) + 50, 200, 20), "Left Mouse");

                GUI.Box(new Rect((Screen.width / 2) + 25, (Screen.height / 2), 200, 70), "RANGED ATTACK:");
                GUI.Label(new Rect((Screen.width / 2) + 100, (Screen.height / 2) + 50, 200, 20), "Right Mouse");

            }
        }


        ////////////////
        // IN-GAME UI
        ////////////////
        if (pauseEnabled == false)
        {
            GUI.Label(new Rect((Screen.width / 2) - 75, 10, 140, 20), "Objects in Possession:");

            if (StealObjectScript.isObjectTaken && GUIMainMenu.stealGameMode)
            {
                GUI.Label(new Rect((Screen.width / 2) - 75, 30, 140, 20), "1x Stealable Object");
            }
            if (ExitZone.objectiveCompleted)
            {
                GUI.Label(new Rect((Screen.width / 2) - 75, (Screen.height / 2), 140, 20), "Objective Completed");
                GUI.Label(new Rect((Screen.width / 2) - 75, (Screen.height / 2) + 100, 140, 20), "Ending Game in " + (int) ExitZone.endGameTimer);
            }
        }
    }
}
