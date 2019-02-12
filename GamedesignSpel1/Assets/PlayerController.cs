using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float movementSpeed = 10.0f;
	public float jumpForce = 10.0f;

	private Rigidbody rb;
	private Quaternion cameraRotation = Quaternion.Euler(0, 45, 0);
	public int score = 0;

	private GameObject camera;
	public float cameraHeightOffset = 2.0f;
	private float heightOfFloor = 0;

	public int getScore() {
		return score;
	}

	public void addScore(int score) {
		this.score += score;
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		camera = GameObject.Find("Main Camera");
	}

	void FixedUpdate() {
		float dx = Input.GetAxis("Horizontal");
		float dy = Input.GetAxis("Vertical");

		rb.AddForce(cameraRotation * new Vector3(dx, 0.0f, dy) * movementSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		bool isOnFloor = Physics.Raycast(transform.position, Vector3.down, out hit, transform.localScale.y);
		if (isOnFloor) {
			heightOfFloor = hit.point.y;
			if (Input.GetKeyDown("space")) {
				rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
			}
		}

		camera.transform.position = new Vector3(
			transform.position.x,
			Mathf.Min(transform.position.y, heightOfFloor) + cameraHeightOffset,
			transform.position.z);
		camera.transform.Translate(Vector3.back * 20.0f);
	}
}
