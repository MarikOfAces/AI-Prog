using UnityEngine;
using System.Collections;
using System;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public float speed;
    public Vector3 velocity;
    public float Noise;

	public bool canClimb;
	public bool climbMode;
	public bool isClimbing = false;
	float mouseSensitivity = 5.0f;

	RaycastHit hasHit;
	Vector3 climbVector;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
		speed = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		ControllPlayer();
		Vector3 rayPos = transform.position - new Vector3 (0, 0.5f, 0);
		Debug.DrawRay(rayPos, transform.forward * 1.0f, Color.black);
		//Debug.DrawRay(transform.position, -transform.forward * 1.0f, Color.black);
		//Debug.DrawRay(transform.position, transform.right * 1.0f, Color.black);
		//Debug.DrawRay(transform.position, -transform.right * 1.0f, Color.black);
	}

    void FixedUpdate()
    { 
		Vector3 rayPos = transform.position - new Vector3 (0, 0.5f, 0);
		if ((Physics.Raycast (rayPos, transform.forward, out hasHit, 1.0f)) && (hasHit.collider.tag == "Climb")) {
			canClimb = true;		
			print ("canClimb = true");
		}else {
			canClimb = false;	
		}
		if (canClimb == false) {
			//climbMode = false;
		}


		if (canClimb && playerMovementController.useAction) {
			climbMode = true;
			print ("ClimbMode = true");
		}
		//if (playerMovementController.useAction && isClimbing) {
			//print ("climb OFF");
			//climbMode = false;
		//}
		if (!canClimb){
			print("Disconected from wall");
			playerMovementController.usePressed = false;
			playerMovementController.useAction = false;
			climbMode = false;
		}
		if (climbMode) {
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");	
			Vector3 movement = new Vector3 (moveHorizontal, moveVertical*1.5f, 0.0f);
			moveHorizontal *= speed;
			moveVertical *= speed;
			transform.Translate(new Vector3(moveHorizontal,moveVertical,0));
			print ("Climbmode");
			gameObject.GetComponent<Rigidbody>().useGravity = false;
			if (playerMovementController.useAction){
				print ("leave wall");
				climbMode = false;
				canClimb = false;
			}

		} else {
			gameObject.GetComponent<Rigidbody>().useGravity = true;
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");
			moveHorizontal *= speed;
			moveVertical *= speed;
			transform.Translate(new Vector3(moveHorizontal,0,moveVertical));
			//Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
			//velocity = rb.velocity;
			//Noise = ((rb.velocity.x) * (rb.velocity.x) + (rb.velocity.z) * (rb.velocity.z));
			//rb.AddForce (movement * speed);
			//print ("Normal Movement");
			float rotY = Input.GetAxis ("Mouse X") * mouseSensitivity;
			transform.Rotate (0, rotY, 0);
		}
    }

    internal void updatePlayerHp(int guardDmg)
    {
        throw new NotImplementedException();
    }
	void ControllPlayer()
	{
		float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		float moveVertical = Input.GetAxisRaw ("Vertical");
		moveHorizontal *= speed;
		moveVertical *= speed;
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		if(moveHorizontal != 0 || moveVertical != 0)
		{
			//transform.rotation = Quaternion.LookRotation(movement);
		}
		
		
		//transform.Translate (movement * speed * Time.deltaTime, Space.World);

	}
}
