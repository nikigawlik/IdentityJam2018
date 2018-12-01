using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public string horizontalInputAxis = "Horizontal";
	public string verticalInputAxis = "Vertical";

	public GameObject followObject;
	public float followLerp = 12f;
	public Vector2 rotateSpeed = new Vector2(90f, 90f);
	public float angleLimitLower = 85f;
	public float angleLimitUpper = 85f;

	private Vector3 eulerAngels;

    public Vector3 EulerAngles
    {
        get
        {
            return eulerAngels;
        }
    }


    // Use this for initialization
    private void Start () {
		eulerAngels = transform.rotation.eulerAngles;
	}

	private void FixedUpdate() {
		// follow target
		transform.position = Vector3.Lerp(transform.position, followObject.transform.position, followLerp * Time.deltaTime);
	}
	
	// Update is called once per frame
	private void Update () {
		// mouse lock
		if(Input.GetMouseButtonDown(0)) {
			
			Cursor.lockState = CursorLockMode.Locked;
		}

		// input
		Vector2 input = new Vector2(
			Input.GetAxis(verticalInputAxis), 
			Input.GetAxis(horizontalInputAxis)
		);

		// add camera rotation
		eulerAngels.x += input.x * rotateSpeed.x * Time.deltaTime;
		eulerAngels.y += input.y * -rotateSpeed.y * Time.deltaTime;

		eulerAngels.x = Mathf.Clamp(eulerAngels.x, angleLimitLower, angleLimitUpper);

		transform.rotation = Quaternion.Euler(eulerAngels);
	}
}
