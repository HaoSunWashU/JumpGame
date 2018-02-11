using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;


	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position; //relative position between camera and player
	}

	// Update is called once per frame
	void LateUpdate () { //call after other object update
		transform.position = player.transform.position + offset; 
	}
}
