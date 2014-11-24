using UnityEngine;
using System.Collections;

public class DropTrap : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () {
	
		player = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player") 
		{
			player.gameObject.GetComponent<PlayerHealth> ().TakeDamage (3);	
		} 

		if (coll.gameObject.tag == "Ground") 
		{
			rigidbody2D.isKinematic = true;
			collider2D.isTrigger = false;
		}

	}


}
