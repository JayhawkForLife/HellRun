using UnityEngine;
using System.Collections;


public class CheckPoint : MonoBehaviour 
{

	Animator anim;
	GameObject player;

	GameObject pHealth;
	public PlayerHealth pH;

	public bool startCP = false;
	bool playerOnCP = false;


	
	void Start () {
		
		anim = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag("Player");
		//pHealth = GameObject.Find ("PlayerHealth");

	}

	void Update () 
	{
		if (playerOnCP) 
		{
			startCP = true;
			anim.SetBool ("startCP", startCP);

			pH.setSpawnPoint(this.gameObject);
		}
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
			playerOnCP = true;
        }
    }
}
