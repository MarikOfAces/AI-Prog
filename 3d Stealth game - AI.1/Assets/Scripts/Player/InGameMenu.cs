using UnityEngine;
using System.Collections;
using System;

public class InGameMenu : MonoBehaviour
{
    private bool pauseEnabled;
    public GameObject playerGO;

    public GUISkin inGameMenuSkin;

    void Start()
    {
        pauseEnabled = false;
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    void Update()
    {
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
        GUI.skin = inGameMenuSkin;

        if (pauseEnabled == true)
        {                 
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 150, 250, 300), "PAUSED");

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 250, 40), "Resume"))
            {
                pauseEnabled = false;
                Time.timeScale = 1;
                AudioListener.pause = false;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 250, 40), "Restart Level"))
            {
                Application.LoadLevel(Application.loadedLevel);
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
   }
}
