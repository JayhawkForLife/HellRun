using UnityEngine;
using System.Collections;

public class BuzzSaw : MonoBehaviour {

	int rotationSpeed = 200;

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
			Debug.Log("Player touching buzzsaw");
			coll.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
		}
		if (coll.gameObject.tag == "Enemy") 
		{
			Debug.Log ("Enemy touching buzzsaw");
			coll.gameObject.GetComponent<EnemyHealth>().DecrementHealth();
			int currentHealth = coll.gameObject.GetComponent<EnemyHealth>().GetHealth();
			if(currentHealth == 0)
			{
				coll.gameObject.GetComponent<DogsAI>().isDead = true;
			}
		}
	}
	
}
