using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour {

	GameObject player;
	bool playerOnAmmo = false;
	public int ammoAmount;

	// Use this for initialization
	void Start () {
		
		player = GameObject.FindGameObjectWithTag("Player");
		ammoAmount = 5;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E) && playerOnAmmo)
		{
			if (player.gameObject.GetComponentInChildren<TommyGun>().getCurrentAmmo() < 30)
			{
				player.gameObject.GetComponentInChildren<TommyGun>().addAmmo(ammoAmount);
				Destroy(this.gameObject);
			}
			else
			{
				Debug.Log ("Cannot carry anymore Ammo!");
			}
		}
	}
	
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			Debug.Log("Player touching ammo");
			playerOnAmmo = true;
			
		}
		if (coll.gameObject.tag == "Ground") 
		{
			rigidbody2D.isKinematic = true;
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			playerOnAmmo = false;
		}
	}
}