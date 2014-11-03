using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<EnemyHealth>().DecrementHealth();
            int currentHealth = other.gameObject.GetComponent<EnemyHealth>().GetHealth();
            if(currentHealth == 0)
            {
                other.gameObject.GetComponent<DogsAI>().isDead = true;
            }
            
        }
    }
}
