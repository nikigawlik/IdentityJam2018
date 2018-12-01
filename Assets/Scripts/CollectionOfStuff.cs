using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionOfStuff : MonoBehaviour {
	public List<Collectable> collectedObjects;
	public float minOrbitRadius = 2f;
	public float orbitRadiusIncrease = 2f;
	public int maxCollectables = 4;

	// Use this for initialization
	void Start () {
		collectedObjects = new List<Collectable>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddCollectable(Collectable c) {
		// drop collectibles
		if(collectedObjects.Count >= maxCollectables) {
			Collectable dropThis = collectedObjects[Random.Range(0, collectedObjects.Count)];
			collectedObjects.Remove(dropThis);
			
			// remove orbit
			Object.Destroy(dropThis.GetComponent<Orbit>());
			MoveTo mt = dropThis.gameObject.AddComponent<MoveTo>();
			mt.targetPosition = c.transform.position;
			dropThis.transform.SetParent(null);

			// reenable stuff
			InteractableObject io = dropThis.gameObject.GetComponent<InteractableObject>();
			io.enabled = true;
			Collider col = io.GetComponent<Collider>();
			col.enabled = true;

            ParticleSystem ps = dropThis.GetComponentInChildren<ParticleSystem>();
            ParticleSystem.EmissionModule em;
            em = ps.emission;
            em.enabled = true;
        }

		collectedObjects.Add(c);
		Orbit orbit = c.gameObject.AddComponent<Orbit>();
		orbit.target = transform;
		orbit.radius = minOrbitRadius + (collectedObjects.Count - 1) * orbitRadiusIncrease;

		c.transform.SetParent(transform);
	}
}
