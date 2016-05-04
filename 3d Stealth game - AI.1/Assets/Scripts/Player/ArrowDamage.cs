using UnityEngine;
using System.Collections;

public class ArrowDamage : MonoBehaviour {
	float thrust;
	GameObject shotGuard;
	// Use this for initialization
	void Start () {
		thrust = 3000.0f;
		Rigidbody rb = gameObject.GetComponent<Rigidbody>();
		rb.AddForce (transform.forward * thrust);
	}
	
	// Update is called once per frame
	void Update () {


		//rb.velocity = transform.forward * 10.0f;
	}

	void OnTriggerEnter(Collider Other){
		print ("hit target");

		if (Other.GetComponent<MoveTo>()) {
			shotGuard = (Other.gameObject);
			print ("HitGuard");
		} else if (Other.GetComponent<eliteController>()) {
			shotGuard = (Other.gameObject);
			print ("HitElite");
		} else if (Other.GetComponent<rangedController>()) {
			shotGuard = (Other.gameObject);
			print ("HitRanged");
		} else
			print ("No enemies");
		if (shotGuard != null) {

				Destroy(shotGuard);
			Destroy(gameObject);
		}
	//}
	}
}
	