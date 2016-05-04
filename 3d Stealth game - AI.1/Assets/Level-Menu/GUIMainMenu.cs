using UnityEngine;
using System.Collections;

public class GUIMainMenu : MonoBehaviour
{
    public bool isMainMenu;
    public bool isMainMenuGameModes;
    public bool isMainMenuOptions;

    static public bool noGameMode;
    static public bool stealGameMode;
    static public bool assassinateGameMode;
    static public bool escortGameMode;
    static public bool escapeGameMode;

    public GUISkin mainMenuSkin;

    void Start()
    {
        isMainMenu = true;
        isMainMenuOptions = false;
        isMainMenuGameModes = false;
        Time.timeScale = 1;

        noGameMode = false;
        stealGameMode = false;
        assassinateGameMode = false;
        escortGameMode = false;
        escapeGameMode = false;
    }

    void Update()
    {
        if (Application.loadedLevel != 0)
        {
            this.enabled = false;
        }
    }

    void OnGUI()
    {
        GUI.skin = mainMenuSkin;
        if (isMainMenu)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "MAIN MENU");

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 200, 250, 40), "Choose Game Mode"))
            {
                isMainMenuGameModes = true;
                isMainMenu = false;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2, 250, 40), "Options"))
            {
                isMainMenuOptions = true;
                isMainMenu = false;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 100, 250, 40), "Quit Application"))
            {
                Application.Quit();
            }
        }

        if (isMainMenuGameModes == true)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "GAME MODES");

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 200, 250, 50), "No Objective"))
            {
                noGameMode = true;
                Application.LoadLevel(1);
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 125, 250, 50), "Steal Object"))
            {
                stealGameMode = true;
                Application.LoadLevel(1);
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 250, 50), "Assassination"))
            {
                assassinateGameMode = true;
                Application.LoadLevel(1);
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 25, 250, 50), "Escort"))
            {
                escortGameMode = true;
                Application.LoadLevel(1);
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 100, 250, 50), "Complex Escape"))
            {
                escapeGameMode = true;
                Application.LoadLevel(1);
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 300, Screen.height / 2 + 200, 200, 50), "Back"))
            {
                isMainMenu = true;
                isMainMenuGameModes = false;
            }
        }

        if (isMainMenuOptions == true)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "OPTIONS");

            if (GUI.Button(new Rect(Screen.width / 2 - 300, Screen.height / 2 + 100, 200, 50), "Back"))
            {
                isMainMenuOptions = false;
                isMainMenu = true;
            }
        }
    }
}