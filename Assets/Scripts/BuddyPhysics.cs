using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddyPhysics : MonoBehaviour {

	/** torsoRotationScale scales how quickly (time) the buddy
	tries to stand. */
	public float torsoRotationScale;
	Rigidbody torsoRb;
	Rigidbody head;
	Transform buddyGameObject;
	/*For Whether the Buddy is knocked out. */
	public bool knockedOut;
	ParticleSystem sleepZ;

	public float buddyHealth;

	
	// Use this for initialization
	void Start () {
		torsoRb = gameObject.GetComponent<Rigidbody>();
		buddyGameObject = gameObject.GetComponent<Transform>();
		head = GameObject.Find("Head").GetComponent<Rigidbody>();
		head.mass = 1;
		sleepZ = GameObject.Find("Head").GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		knockOut();
		standUp();
	}

	float knockOutTimer = 10;
	void knockOut () {
		if(knockedOut) {
			knockOutTimer -= Time.deltaTime;
			print(knockOutTimer);
			if(knockOutTimer <= 0) {
				knockOutTimer = 10;
				buddyHealth = 100;
				knockedOut = false;
			}
			torsoRb.useGravity = true;
			head.mass = 1;
			sleepZ.Play();
		} else {
			sleepZ.Pause();
			sleepZ.Clear();
			torsoRb.useGravity = false;
			head.mass = 0;
		}
		// if(Input.GetMouseButtonDown(0)) {
		// 	if (knockedOut) {
		// 		knockedOut = false;
		// 	} else {
		// 		knockedOut = true;
		// 	}	
		// }

		if(Input.GetMouseButtonDown(0)) {
			buddyHealth -= 10;
		}

		if(buddyHealth <= 0) {
				knockedOut = true;
		}

	}

	void standUp() {
		var planarFwd = transform.forward;
		planarFwd.y = 0;
		float vx = torsoRb.velocity.x * 0.9f;
		float vz = torsoRb.velocity.z * 0.9f;
		Vector3  veloVect = new Vector3(vx, torsoRb.velocity.y, vz);

		if (!knockedOut) {
			torsoRb.rotation = Quaternion.RotateTowards(torsoRb.rotation, Quaternion.LookRotation(planarFwd), torsoRotationScale * Time.deltaTime);
		}

		torsoRb.velocity = veloVect;
	}
}