using UnityEngine;
using System.Collections;

public class LightDetection : MonoBehaviour {

    public Light lightSource;
    public GameObject player;

    float distanceToLight;
    public float lightLevel; 

    static public bool playerIlluminated;

    // Use this for initialization
    void Start () {
        lightSource = GetComponent<Light>();

        playerIlluminated = false;
    }
	
	// Update is called once per frame
	void Update () {
        distanceToLight = Vector3.Distance(player.transform.position, transform.position);
        lightLevel = (lightSource.range + lightSource.intensity) / 2;
        Debug.Log(lightLevel);

        if (distanceToLight <= lightLevel)
        {
            playerIlluminated = true;
            Debug.Log("PLAYER ILLUMINATED");
        }
        else { playerIlluminated = false; Debug.Log("NO DETECTION"); }    
    }
}
