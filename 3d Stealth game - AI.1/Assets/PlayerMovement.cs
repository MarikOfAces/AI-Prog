using UnityEngine;
using System.Collections;
using System;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public float speed;
    public Vector3 velocity;
    public float Noise;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        velocity = rb.velocity;
        Noise = ((rb.velocity.x) * (rb.velocity.x) + (rb.velocity.z) * (rb.velocity.z));
        rb.AddForce(movement * speed);
    }

    internal void updatePlayerHp(int guardDmg)
    {
        throw new NotImplementedException();
    }
}
