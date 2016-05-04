using UnityEngine;
using System.Collections;

public class movingFlockCenter : MonoBehaviour {

    bool moveUp;
	// Use this for initialization
	void Start () {
        moveUp = true;
    }
    Vector3 move = new Vector3(0.1f, 0, 0);
	// Update is called once per frame
	void Update () {
	    if (transform.position.x <= -55.0f)
        {
            moveUp = true;
        }
        if (transform.position.x >= 55.0f)
        {
            moveUp = false;
        }

        if(moveUp == true)
        {
            transform.position += move;
        }
        else { transform.position -= move; }
    }
}
