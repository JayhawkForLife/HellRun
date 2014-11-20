using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class DogsAI : MonoBehaviour {

    GameObject player;
    Transform playerTransform;
    Sight sight;
    Animator anim;

    float speed;
    float chaseDistance = 10f;
    float attackDistance = 5f;
    float attackTimer;

    public int damage;

    public bool isFacingRight { get; private set; }
    public bool isDead { get; set; }
    public bool canAttack { get; private set; }
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        sight = GetComponentInChildren<Sight>();
        anim = GetComponent<Animator>();
        
        isDead = false;
        
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
	    if(attackTimer <= 0)
        {
            canAttack = true;
=======
	    if(attackTimer <= 0)
        {
            canAttack = true;
        }
        else
        {
            canAttack = false;
            attackTimer -= Time.deltaTime;
        }
	}

    void FixedUpdate()
    {
        StartCoroutine(Dead());
        // Cache the horizontal input.
        float h = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(rigidbody2D.velocity.x));
        // if the dog can see the player, run towards the player

        if(!isDead)
        {
            if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
            {
                speed = 8f;
                rigidbody2D.velocity = new Vector2(sight.playerPos.direction.x * speed, 0);
                if (sight.playerPos.direction.magnitude < 1)
                    sight.playerPos.direction = sight.playerPos.direction.normalized;
                
                // Flip dirrection base on which way the enemy is moving 
                //FlipDirection();
            }
            
            if(Vector2.Distance(transform.position, playerTransform.position) < attackDistance)
            {
                if(canAttack)
                {
                    Debug.Log("I am attacking u");
                    speed = 0;
                    //anim.SetBool("canAttack", true);
                    player.GetComponent<PlayerHealth>().SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
                    attackTimer += 1f;
                }
                
            }
            else if (Vector2.Distance(transform.position, playerTransform.position) > attackDistance)
            {
                //anim.SetBool("canAttack", false);
                

            }
>>>>>>> origin/master
        }
        else
        {
            canAttack = false;
            attackTimer -= Time.deltaTime;
        }
	}

    void FixedUpdate()
    {
        StartCoroutine(Dead());
        // Cache the horizontal input.
        float h = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(rigidbody2D.velocity.x));
        // if the dog can see the player, run towards the player

        if(!isDead)
        {
            if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
            {
                speed = 8f;
                rigidbody2D.velocity = new Vector2(sight.playerPos.direction.x * speed, 0);
                if (sight.playerPos.direction.magnitude < 1)
                    sight.playerPos.direction = sight.playerPos.direction.normalized;
                
                // Flip dirrection base on which way the enemy is moving 
                //FlipDirection();
            }
            
            if(Vector2.Distance(transform.position, playerTransform.position) < attackDistance)
            {
                if(canAttack)
                {
                    Debug.Log("I am attacking u");
                    speed = 0;
                    anim.SetBool("canAttack", true);
                    player.GetComponent<PlayerHealth>().SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
                    attackTimer += 1f;
                }
                
            }
            else if (Vector2.Distance(transform.position, playerTransform.position) > attackDistance)
            {
                //anim.SetBool("canAttack", false);
                

            }
        }
        
    }

    private void FlipDirection()
    {
        if (sight.playerPos.direction.x < 0)
        {
            transform.localScale = new Vector2(-1f, transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(1f, transform.localScale.y);
        }
        
        
    }

    private IEnumerator Dead()
    {
        if(isDead)
        {
            anim.SetBool("isDead", true);
            rigidbody2D.velocity = new Vector2(0, 0);
            yield return new WaitForSeconds(2f);
            Destroy(gameObject);
            
        }
    }

    


}
