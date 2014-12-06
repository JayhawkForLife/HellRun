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
    
	public GameObject currentSpawnPoint;
	int spawnHeight = 3;


    Animator anim;
	// Use this for initialization
	void Start () {
		maxHealth = 3;
		currentHealth = maxHealth;
		testTrans = ((GameObject)Instantiate (healthGUI.gameObject)).transform;
		
		camera = GameObject.FindGameObjectWithTag("MainCamera");

		currentSpawnPoint = GameObject.FindGameObjectWithTag("StartPoint");

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
		anim.SetBool("isDead", false);

		gameObject.transform.position = new Vector2(currentSpawnPoint.gameObject.transform.position.x,currentSpawnPoint.gameObject.transform.position.y + spawnHeight);
		camera.transform.position = new Vector3(currentSpawnPoint.gameObject.transform.position.x, currentSpawnPoint.gameObject.transform.position.y, -10f);
        
		currentHealth = maxHealth;
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

	public void setSpawnPoint(GameObject CP)
	{
		currentSpawnPoint = CP;
	}
}
