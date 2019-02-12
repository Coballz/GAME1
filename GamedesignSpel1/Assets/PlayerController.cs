using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float movementSpeed = 10.0f;

	private Rigidbody rb;
	private Quaternion cameraRotation = Quaternion.Euler(0, 45, 0);

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate() {
		float dx = Input.GetAxis("Horizontal");
		float dy = Input.GetAxis("Vertical");

		rb.AddForce(cameraRotation * new Vector3(dx, 0.0f, dy) * movementSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
