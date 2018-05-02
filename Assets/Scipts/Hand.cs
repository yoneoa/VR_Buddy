using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

	public OVRInput.Controller controller;

	private float indexTriggerState = 0;
	private float handTriggerState = 0;
	private float oldIndexTriggerState = 0;

	private bool holdingWeapon = false;
	private GameObject weapon = null;

	// Dictionary of weapon tag and hold [Position, Rotation]
	private Dictionary<string, Vector3[]> weaponHolds = new Dictionary<string, Vector3[]>  
	{
		{ "Katana", new[]{new Vector3(0, 0.08f, 0), new Vector3(110.0f,0, 0)}},
		{ "Axe", new[]{new Vector3(-0.039f, 0.337f, 0.065f), new Vector3(-76f, -40f, 220f)}},
		{ "Dagger", new[]{new Vector3(0.0027f, 0.0242f, -0.039f), new Vector3(75f, 160f, 160f)}}
	};


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		oldIndexTriggerState = indexTriggerState;
		indexTriggerState = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, controller);
		handTriggerState = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller);

		if (holdingWeapon) {
			if (handTriggerState < 0.9f) {
				Release();
			}
		}
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.GetComponent<Weapon>() != null) {
			if (handTriggerState > 0.9f && !holdingWeapon) {
				Grab(other.gameObject);
			}
		}
	}
	void Grab(GameObject obj) {
		holdingWeapon = true;
		weapon = obj;

		weapon.transform.parent = transform;
		weapon.transform.localPosition = weaponHolds[weapon.tag][0];
		weapon.transform.localEulerAngles = weaponHolds[weapon.tag][1];
	}
	void Release() {
		weapon.transform.parent = null;

		Rigidbody rigidbody = weapon.GetComponent<Rigidbody>();

		rigidbody.useGravity = true;
		rigidbody.isKinematic = false;

		weapon.GetComponent<Weapon> ().released ();

		holdingWeapon = false;
		weapon = null;

		rigidbody.velocity = OVRInput.GetLocalControllerVelocity(controller);
	}
}
