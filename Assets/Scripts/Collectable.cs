using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

	private InteractableObject io;

	// Use this for initialization
	void Start () {
		io = GetComponentInParent<InteractableObject>();
		io.OnInteraction = OnPickup;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnPickup(GameObject p) {
		CollectionOfStuff cos = p.GetComponent<CollectionOfStuff>();

		cos.AddCollectable(this);

		GameObject.Destroy(io.gameObject);
	}
}
