using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddyDamage : MonoBehaviour {

	// Use this for initialization
	GameObject buddy;
	BuddyPhysics buddyPhys;
	string[] bodyParts;

	GameObject self;

	public float damageScalar;
	float damage;

	void Start () {
		buddy = GameObject.Find("Buddy");
		buddyPhys = GameObject.Find("Torso").GetComponent<BuddyPhysics>();
		bodyParts = new string[]{"Head", "Torso", "HandR", "HandL", "FootR", "FootL"};
		self = this.gameObject;
	}

	void OnCollisionEnter(Collision col) {
		float notBodyOnBody = System.Array.IndexOf(bodyParts, col.gameObject.name);
		if (notBodyOnBody == -1) {
			float relativeVelo = col.relativeVelocity.magnitude;
			damage = relativeVelo * col.gameObject.GetComponent<Rigidbody>().mass * damageScalar;
			buddyPhys.buddyHealth -= damage;
			print(damage);
			damage = 0;
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
