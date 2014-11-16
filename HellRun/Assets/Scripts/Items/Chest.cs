using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chest : MonoBehaviour {

	Animator anim;
	GameObject player;
	int numberOfItems = 3;
	int item;


	public bool canOpenChest = false;
	public bool openChest = false;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag("Player");
		//Physics2D.IgnoreCollision(this.collider2D, player.collider2D);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E) && canOpenChest) 
		{
			openChest = true;
			anim.SetBool("openChest", openChest);

			canOpenChest = false;
			Debug.Log("Player opened chest");

			item = Random.Range (0, numberOfItems);

			if (item == 0)
			{
				// Health pack
				Debug.Log ("Health pack");

				// As of now, player automatically heals 1 if they get health pack from chest.
				// Eventually health pack object will be instantiated on top of the chest
					// and the player must press E on top of the health pack object to heal
				player.gameObject.GetComponent<PlayerHealth>().Heal(1);
			}
			else if(item == 1)
			{
				// Ammo
				Debug.Log ("Ammo");
				// Need to change Ammo functions
				// Eventually ammo object will be instantiated on top of the chest
					// and the player must press E on top of the ammo object to gain 10 bullets
			}
			else if(item == 2)
			{
				// Bomb
				Debug.Log("Bomb");

				// As of now, player automatically loses 1 health if they get bomb from chest.
				// Eventually bomb object will be instantiated on top of the chest 
					// and the player will have a certain amount of seconds to leave the area before the bomb explodes
				player.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
			}

		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			Debug.Log("Player touching chest");
			canOpenChest = true;
		}
	}
}
