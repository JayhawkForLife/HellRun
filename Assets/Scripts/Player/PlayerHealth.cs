using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int maxHealth;
	public int currentHealth;
	public GUITexture healthGUI;
	public Texture[] images;
	public Transform testTrans;

    public bool isDead { get; private set; }

    GameObject camera;
    GameObject startPoint;
    Animator anim;
	// Use this for initialization
	void Start () {
		maxHealth = 3;
		currentHealth = maxHealth;
		testTrans = ((GameObject)Instantiate (healthGUI.gameObject)).transform;
		
		camera = GameObject.FindGameObjectWithTag("MainCamera");
		//startPoint = GameObject.FindGameObjectWithTag("StartPoint");
		anim = GetComponent<Animator>();
	}

	public void ModifyHealth(int amount) {
		Debug.Log ("Modifying : " + amount);
		for (int i = 0; i < Mathf.Abs (amount); i++){
			if (amount > 0 && currentHealth < maxHealth){
				currentHealth++;
			}
			else{
				if (currentHealth > 0) {
					currentHealth--;
				}
			}
		}
		UpdateHealth ();
	}

	public void UpdateHealth() {
		testTrans.guiTexture.texture = images [currentHealth];
	}

	// Update is called once per frame
	void Update () {
		UpdateHealth ();
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
       yield return new WaitForSeconds(1f);
       Respawn();
        
    }

    public void Respawn()
    {
        //gameObject.transform.position = new Vector2(startPoint.gameObject.transform.position.x,startPoint.gameObject.transform.position.y);
		gameObject.transform.position = new Vector2(56,307);
		camera.transform.position = new Vector3(56, 307, -10f);

		//camera.transform.position = new Vector3(startPoint.gameObject.transform.position.x, startPoint.gameObject.transform.position.y, -10f);
        currentHealth = maxHealth;
        anim.SetBool("isDead", false);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Ouch");
		ModifyHealth (-damage);

    }

	public void Heal (int healAmount)
	{
		ModifyHealth (healAmount);
	}

    public int getCurrentHealth()
    {
        return currentHealth; 
    }
}
