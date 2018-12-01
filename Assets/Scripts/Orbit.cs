using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {
	public Transform target;
	public float radius = 1f;
	public float minSpeed = 2f;
	public float maxSpeed = 3f;
	public float lerpSpeed = 1f;
	public float angleOffset = 15f;

	private Quaternion currentRotation;
	private Quaternion deltaRotation;

	// Use this for initialization
	void OnEnable () {
		if(target == null) {
			target = transform.parent;
		}

		currentRotation = Quaternion.Euler(Random.Range(-angleOffset, angleOffset), 0, 0);
		// deltaRotation = Quaternion.Euler(Random.Range(minSpeed, maxSpeed) * (Random.Range(0, 2) - .5f) * 2f, 0, 0);
		deltaRotation = Quaternion.Euler(0, Random.Range(minSpeed, maxSpeed), 0);
	}
	
	// Update is called once per frame
	void Update () {
		currentRotation = currentRotation * deltaRotation;
		Vector3 targetPoint = target.position + currentRotation * Vector3.right * radius;
		transform.position = Vector3.Lerp(transform.position, targetPoint, lerpSpeed * Time.deltaTime);
	}
}
