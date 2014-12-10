using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public int health;
	public AudioClip monsterSound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DecrementHealth()
    {
		if (monsterSound != null) 
		{
			AudioSource.PlayClipAtPoint(monsterSound,transform.position);		
		}
        health--;
    }

    public int GetHealth()
    {
        return health;
    }
}
