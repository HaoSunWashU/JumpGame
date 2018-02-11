using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
	private Vector3 originalPos;
	private Vector3 targetPos;
	public float speed;
	// Use this for initialization
	void Start () {
		originalPos = transform.position;
		targetPos = new Vector3 (transform.position.x + 18.0f/6.0f * speed, transform.position.y, transform.position.z);
	}

	//123
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3(15, 30, 45) * Time.deltaTime);

		float moveStep = Time.deltaTime * speed;
		transform.position = Vector3.MoveTowards (transform.position, targetPos, moveStep);

		if (transform.position == targetPos) {
			targetPos = originalPos;
		}
		if (transform.position == originalPos) {
			targetPos = new Vector3 (transform.position.x + 18.0f/6.0f * speed, transform.position.y, transform.position.z);
		}
	}
}
