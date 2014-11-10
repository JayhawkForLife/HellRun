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
			Debug.Log("Touching buzzsaw");
			coll.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
		}
	}
	
}
