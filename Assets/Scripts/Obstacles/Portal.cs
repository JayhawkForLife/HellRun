using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

	GameObject player;
	GameObject camera;

	public GameObject Destination;

	bool playerOnPortal = false; // Checks if player is touching the chest

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		camera = GameObject.FindGameObjectWithTag("MainCamera");

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E) && playerOnPortal) 
		{

			//Debug.Log("Player entered portal");
			player.transform.position = new Vector2(Destination.transform.position.x,Destination.transform.position.y+2);
			camera.transform.position = new Vector3(Destination.transform.position.x,Destination.transform.position.y, -10f);
		}
	}
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			playerOnPortal = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			playerOnPortal = false;
		}
	}
}
