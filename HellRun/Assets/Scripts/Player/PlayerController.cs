using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 10f;
    public float jumHeight = 10f;
    public float acceleration;

    private float currentSpeed;
    private float targetSpeed;

    public bool isFacingRight { get; private set; }
    public bool isGrounded { get; private set; }
    public bool onPlatform { get; private set; }
    public bool canJump { get; private set; }
    public bool isDead { get; private set; }
    public bool isClimbing { get; set; }

    public LayerMask groundLayer;
    public LayerMask movingPlatformLayer;

    Rigidbody2D rBody2D;
    private Transform groundCheck;
    public Transform[] platforms;
    private Transform currentPlatform = null;
    Vector3 lastPlatformPosition = Vector3.zero;
    Vector3 currentPlatformDelta;
    Animator anim;
    PlayerHealth health;

	// Use this for initialization
	void Start () {
        isFacingRight = true;
        isGrounded = true;
        canJump = true;
        isDead = false;
        isClimbing = false;

        rBody2D = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck");
        currentPlatformDelta = Vector2.zero;
        anim = GetComponent<Animator>();
        health = gameObject.GetComponent<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if (isGrounded && !isClimbing)
        {
            canJump = true;
            rigidbody2D.gravityScale = 1;
        }
        else
        {
            canJump = false;
        }

        
            
       

        
       

       
        
	
	}

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapPoint(groundCheck.position, groundLayer);
        
        onPlatform = Physics2D.OverlapPoint(groundCheck.position, movingPlatformLayer);
        if (!isDead)
            HandleUserInput();
    }

    private void HandleUserInput()
    {
        float s = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(s));

       
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            if (!isFacingRight)
                FlipPlayerDirection();
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (isFacingRight)
                FlipPlayerDirection();
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
        }


        if(canJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Jump");
                rigidbody2D.AddForce(new Vector2(0f, 1000f));
                canJump = false;
            }
        }
        
     

        if(isClimbing == true)
        {
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }

            if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(-Vector2.up * speed * Time.deltaTime);
            }
        }


        // Determine how far the platform has moved
        
        
    }

    private void FlipPlayerDirection()
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        isFacingRight = transform.localScale.x > 0;
    }

    



    public void SetGravity(int gravity)
    {
        rBody2D.gravityScale = gravity;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Weakness")
        {
            other.GetComponentInParent<DogsAI>().isDead = true;
        }
        
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if(hit.gameObject.tag == "Moving")
        {
            Debug.Log("On moving platform");
            transform.parent = hit.transform;
        }
        else
        {
            transform.parent = null;
        }
    }

    

    

   

}
