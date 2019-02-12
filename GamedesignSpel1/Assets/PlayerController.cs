using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	public float movementSpeed = 10.0f;
	public float jumpForce = 10.0f;

	private Rigidbody rb;
	private Quaternion cameraRotation = Quaternion.Euler(0, 45, 0);
	private int score = 0;

	public int getScore() {
		return score;
	}

	public void addScore(int score) {
		this.score += score;
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate() {
		float dx = Input.GetAxis("Horizontal");
		float dy = Input.GetAxis("Vertical");

		rb.AddForce(cameraRotation * new Vector3(dx, 0.0f, dy) * movementSpeed);

		if (Input.GetKeyDown("space")) {
			bool isOnFloor = Physics.Raycast(transform.position, Vector3.down, transform.localScale.y);
			if (isOnFloor) {
				rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
