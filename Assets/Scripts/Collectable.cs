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

		// GameObject.Destroy(io.gameObject);
		io.enabled = false;
		Collider col = io.GetComponent<Collider>();
		col.enabled = false;
	}

	private void OnEnable() {
		InteractableObject io = GetComponent<InteractableObject>();
		if(!io) io = gameObject.AddComponent<InteractableObject>();
		io.display = this.transform;
		Collider sc = GetComponent<Collider>();
		if(!sc) sc = gameObject.AddComponent<SphereCollider>();
		sc.isTrigger = true;
	}
}
