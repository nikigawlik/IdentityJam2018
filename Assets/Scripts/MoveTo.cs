using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour {
	public Vector3 targetPosition;
	public float lerpFactor = 15f;
	public float arriveRadius = .2f;
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(transform.position, targetPosition, lerpFactor * Time.deltaTime);
		if(Vector3.Distance(transform.position, targetPosition) < arriveRadius) {
			Object.Destroy(this);
		}
	}
}
