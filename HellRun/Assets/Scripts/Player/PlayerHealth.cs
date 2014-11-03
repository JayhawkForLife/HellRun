using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;

    public bool increaseHealth { get; private set; }
    public bool isDead { get; private set; }

    GameObject camera;
    GameObject startPoint;
    Animator anim;
	// Use this for initialization
	void Start () {
        increaseHealth = false;
        maxHealth = 3;
        currentHealth = maxHealth;

        camera = GameObject.FindGameObjectWithTag("MainCamera");
        startPoint = GameObject.FindGameObjectWithTag("StartPoint");
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (increaseHealth)
            currentHealth = maxHealth;
        if(currentHealth <= 0)
        {
            KillPlayer();
        }
        
	}

    private void KillPlayer()
    {
        StartCoroutine(KillPlayerCo());
    }

    private IEnumerator KillPlayerCo()
    {
       anim.SetBool("isDead", true);
       yield return new WaitForSeconds(2f);
       Respawn();
        
    }

    public void Respawn()
    {
        gameObject.transform.position =new Vector2(startPoint.gameObject.transform.position.x,startPoint.gameObject.transform.position.y);
        camera.transform.position = new Vector3(startPoint.gameObject.transform.position.x, startPoint.gameObject.transform.position.y, -10f);
        currentHealth = maxHealth;
        anim.SetBool("isDead", false);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Ouch");
        currentHealth -= damage;

    }

    public int getCurrentHealth()
    {
        return currentHealth; 
    }
}
