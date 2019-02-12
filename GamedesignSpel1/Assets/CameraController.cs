using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float heightOffset = 2.0f;

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position = player.transform.position;
		transform.position = new Vector3(
			player.transform.position.x,
			heightOffset,
			player.transform.position.z);
		transform.Translate(Vector3.back * 20.0f);
	}
}
