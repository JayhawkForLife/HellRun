using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {

    GameObject player;
    PlayerController pc;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");

        pc = player.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            pc.isClimbing = true;
            
            pc.SetGravity(0);
            Debug.Log("Enter Ladder");
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            pc.isClimbing = false;
            pc.SetGravity(1);
            Debug.Log("Exit Ladder");
        }
    }
}
