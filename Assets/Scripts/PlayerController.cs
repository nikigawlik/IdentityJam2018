using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public string horizontalInputAxis = "Horizontal";
	public string verticalInputAxis = "Vertical";

	public float moveSpeed = 5f;
	public float brakeSpeed = 4f;
	public float verticalBreakSpeed = 1f;

	public CameraController cameraController;
	public GameObject display;
	
	// Use this for initialization
	private void Start () {
		
	}
	
	// Update is called once per frame
	private void Update () {
		Vector3 input = new Vector3(Input.GetAxis(horizontalInputAxis), 0, Input.GetAxis(verticalInputAxis));
		input = Quaternion.Euler(0, cameraController.EulerAngles.y, 0) * input;

		display.transform.rotation = Quaternion.Euler(0, cameraController.EulerAngles.y, 0);
		
		Rigidbody rb = GetComponent<Rigidbody>();
		rb.AddForce(input * (moveSpeed + brakeSpeed));
		rb.AddForce(Vector3.Scale(-rb.velocity, new Vector3(brakeSpeed, verticalBreakSpeed, brakeSpeed)));

		// interaction is handled in the interactible objects ;)
	}

	private void OnValidate() {
		Transform t = transform.Find("Display");
		if(t) display = t.gameObject;
	}
}
