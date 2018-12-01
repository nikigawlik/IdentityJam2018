using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {
	public float highlightScale = 1.5f;
	public float highlightDecay = 5f;
	public float highlightBuildup = 15f;
	public Transform display;

	private float scale;

	private void OnTriggerStay(Collider other) {
		PlayerController pc = other.GetComponent<PlayerController>();
		if(pc) {
			display.localScale = Vector3.Lerp(display.localScale, Vector3.one * highlightScale, highlightBuildup * Time.fixedDeltaTime);
		}
	}

	private void FixedUpdate() {
		display.localScale = Vector3.Lerp(display.localScale, Vector3.one, highlightDecay * Time.fixedDeltaTime);
	}
}
