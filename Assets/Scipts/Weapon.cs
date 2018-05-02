using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	// Store the Weapon's position on the Wall 
	private Vector3 Wall_Position;
	private Quaternion Wall_Rotation;
	private bool held; 

	// Use this for initialization
	void Start () {
		Wall_Position = transform.position;
		Wall_Rotation = transform.rotation;
	}

	public void released ()
	{
		StartCoroutine(back_to_wall());
	}

	IEnumerator back_to_wall()
	{
		yield return new WaitForSeconds(2.0f);
		transform.position = this.Wall_Position;
		transform.rotation = this.Wall_Rotation;

		Rigidbody rigidbody = this.GetComponent<Rigidbody>();

		rigidbody.velocity = Vector3.zero;
		rigidbody.useGravity = false;
		rigidbody.isKinematic = true;


	}
}
