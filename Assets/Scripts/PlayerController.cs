using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary{
	public float xMin, xMax;
}


public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	public float jumpPower;
	private bool canJump;
	public Boundary boundary;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		canJump = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		//detect if the ball can jump. Only the ball is on the floor, it can jump to the air
//		if (canJump) {
		if (Input.GetButtonDown ("Jump")) {
			Vector3 current_v = rb.velocity;
			rb.velocity += new Vector3 (0, jumpPower, 0);
//			canJump = false;
		}
//			//add fraction
//			if (rb.velocity.x > 0.0f) {
//				rb.velocity = new Vector3 (rb.velocity.x - 0.1f, rb.velocity.y, 0);
//			}
//			if (rb.velocity.x < 0.0f) {
//				rb.velocity = new Vector3 (rb.velocity.x + 0.1f, rb.velocity.y, 0);
//			}
//		}
		float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);
		rb.velocity = movement * speed;



//		//if fall into the space, replace the ball to its original place
//		if (transform.position.y < -20.0f){
//			transform.position = new Vector3 (-50.0f, -1.2f, -10f);
//		}

	}

	void OnCollisionEnter(Collision collision){

		if (collision.gameObject.CompareTag("Platform")) {
			canJump = true;
		}

	}
}
