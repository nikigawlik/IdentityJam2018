using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour {
	public float highlightScale = 1.5f;
	public float highlightDecay = 5f;
	public float highlightBuildup = 15f;
	public Transform display;
	public string interactionButton = "Interact";

	public Interact OnInteraction; 

	public delegate void Interact(GameObject p);

	private float scale;
	private PlayerController currentInteractingPlayer = null;

	private void Update() {
		if(currentInteractingPlayer && Input.GetButtonDown(interactionButton)) {
			OnInteraction.Invoke(currentInteractingPlayer.gameObject);
		}
	}

	private void OnTriggerStay(Collider other) {
		PlayerController pc = other.GetComponent<PlayerController>();
		if(pc) {
			display.localScale = Vector3.Lerp(display.localScale, Vector3.one * highlightScale, highlightBuildup * Time.fixedDeltaTime);
		
			currentInteractingPlayer = pc;
		}
	}

	private void OnTriggerExit(Collider other) {
		currentInteractingPlayer = null;
	}

	private void FixedUpdate() {
		display.localScale = Vector3.Lerp(display.localScale, Vector3.one, highlightDecay * Time.fixedDeltaTime);
	}
}
