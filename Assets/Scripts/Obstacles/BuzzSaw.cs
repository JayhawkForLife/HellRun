using UnityEngine;
using System.Collections;

public class BuzzSaw : MonoBehaviour {

	int rotationSpeed = 200;
	public AudioClip buzzSound;
	bool playingSound = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0,0,-rotationSpeed*Time.deltaTime);
	}
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		Debug.Log ("Colliding with an object");
		if(coll.gameObject.tag == "Player")
		{
			if (buzzSound != null && playingSound == false)
			{
				playingSound = true;
				AudioSource.PlayClipAtPoint(buzzSound,transform.position);
			}
			Debug.Log("Player touching buzzsaw");
			coll.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
			playingSound= false;
		}
		if (coll.gameObject.tag == "Enemy") 
		{
			Debug.Log ("Enemy touching buzzsaw");
			if (buzzSound != null && playingSound == false)
			{
				playingSound = true;
				AudioSource.PlayClipAtPoint(buzzSound,transform.position);
			}
			coll.gameObject.GetComponent<EnemyHealth>().DecrementHealth();
			playingSound= false;
			int currentHealth = coll.gameObject.GetComponent<EnemyHealth>().GetHealth();
			if(currentHealth == 0)
			{
				//need to kill all enemies not just dog
				coll.gameObject.GetComponent<DogsAI>().isDead = true;
			}
		}
	}
	
}
