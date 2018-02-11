using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_1 : MonoBehaviour {
	private Rigidbody rb;
	public float speed;
	public float jumpForce;
	private bool canJump;

	void Start(){
		rb = GetComponent<Rigidbody>();
		canJump = false;
	}

	void FixedUpdate(){
//		if (Input.GetKeyDown ("space")) {
//			Vector3 jump = new Vector3 (rb.velocity.x, jumpForce, 0.0f);
//			rb.velocity = jump;
//		}


		if (canJump) {
			if (Input.GetButtonDown ("Jump")) {
				Vector3 jump = new Vector3 (rb.velocity.x, jumpForce, 0.0f);
				rb.velocity = jump;
				canJump = false;
			}
		}
		float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector3 backAndForth = new Vector3 (moveHorizontal * speed, rb.velocity.y, 0.0f);
		rb.velocity = backAndForth;
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.CompareTag ("Platform")) {
			canJump = true;
		}

		if (collision.gameObject.CompareTag ("Enemy") || collision.gameObject.CompareTag ("DeadArea")) {
			transform.position = new Vector3 (-45.0f, -540f, -100f);
		}
	}
}
