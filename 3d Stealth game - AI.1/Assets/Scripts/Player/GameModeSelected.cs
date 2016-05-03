using UnityEngine;
using System.Collections;

public class GameModeSelected : MonoBehaviour {

    public GameObject stealableObject;
    public GameObject escortObject;

    // Use this for initialization
    void Start () {
        stealableObject.SetActive(false);
        escortObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (GUIMainMenu.stealGameMode && StealObjectScript.isObjectTaken == false)
        {
            stealableObject.SetActive(true);
        }
        if (GUIMainMenu.escortGameMode)
        {
            escortObject.SetActive(true);
        }
    }
}
