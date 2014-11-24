﻿using UnityEngine;
using System.Collections;

public class DropTrapTile : MonoBehaviour {


	public bool changeObstacle = false;
	bool alreadyChanged = false;
	//public GameObject trap;
	public GameObject[] traps;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (changeObstacle && !alreadyChanged) 
		{
			alreadyChanged = true;

			// set traps activate value to true
			//trap.GetComponent("DropTrap");
			//trap.rigidbody2D.isKinematic = false;

			Debug.Log("Activating Traps");
			for(int i = 0; i < traps.Length; i++)
			{
				traps[i].GetComponent("DropTrap");
				traps[i].rigidbody2D.isKinematic = false;
			}
		}
	}


	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player") 
		{
			changeObstacle = true;
		}
	}
}
