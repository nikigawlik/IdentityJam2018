using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionOfStuff : MonoBehaviour {
	public List<Collectable> collectedObjects;
	public float minOrbitRadius = 2f;
	public float orbitRadiusIncrease = 2f;

	// Use this for initialization
	void Start () {
		collectedObjects = new List<Collectable>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddCollectable(Collectable c) {
		collectedObjects.Add(c);
		Orbit orbit = c.gameObject.AddComponent<Orbit>();
		orbit.target = transform;
		orbit.radius = minOrbitRadius + (collectedObjects.Count - 1) * orbitRadiusIncrease;

		c.transform.SetParent(transform);
	}
}
