using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddyDamage : MonoBehaviour {

	// Use this for initialization
	GameObject buddy;
	string[] bodyParts;

	GameObject self;

	void Start () {
		buddy = GameObject.Find("Buddy");
		bodyParts = new string[]{"Head", "Torso", "HandR", "HandL", "FootR", "FootL"};
		self = this.gameObject;
	}

	void OnCollisionEnter(Collision col) {
		float notBodyOnBody = System.Array.IndexOf(bodyParts, col.gameObject.name);
		if (notBodyOnBody == -1) {
			float damage = col.relativeVelocity.magnitude;
			print(col.gameObject.name + " : " + damage);

		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
