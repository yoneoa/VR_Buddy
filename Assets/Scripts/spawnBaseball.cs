using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBaseball : MonoBehaviour {
	public GameObject spawnItem;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			Instantiate(spawnItem, new Vector3(0, 3f, -5), Quaternion.identity);
		}
	}

}
