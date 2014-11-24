using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private bool isFacingRight;
   
    private CharacterController2D controller;
    private float normalizeHorizontalSpeed;

    public float maxSpeed = 10f;
    public float speedAccelerationOnGround = 10f;
    public float speedAccelerationInAir = 5f;

    public bool isDead { get; private set; }

    Animator anim;

    public void Awake()
    {
        controller = GetComponent<CharacterController2D>();
        anim = GetComponent<Animator>();
        isFacingRight = transform.localScale.x > 0;
    }

    public void Update()
    {
        if(!isDead)
            HandleInput();

        var movementFactor = controller.playerState.isGrounded ? speedAccelerationOnGround : speedAccelerationInAir;
        controller.SetHorizontalForce(Mathf.Lerp(controller.velocity.x, normalizeHorizontalSpeed * maxSpeed, Time.deltaTime * movementFactor));

        
    }

    private void HandleInput()
    {
        anim.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            normalizeHorizontalSpeed = 1;
            if (!isFacingRight)
                FlipDirection();
        }
        else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            normalizeHorizontalSpeed = -1;
            if (isFacingRight)
                FlipDirection();
        }
        else
        {
            normalizeHorizontalSpeed = 0;
        }

        if(controller.CanJump && Input.GetKeyDown(KeyCode.Space))
        {
            controller.Jump();
        }
    }

    private void FlipDirection()
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        isFacingRight = transform.localScale.x > 0;
    }

    public void KillPlayer()
    {
        //anim.SetBool("isDead", true);
        collider2D.enabled = false;
        isDead = true;
    }

    public void RespawnPlayer()
    {
        if (!isFacingRight)
            FlipDirection();
        anim.SetBool("isDead", false);
        collider2D.enabled = true;
        transform.position = new Vector2(0,0);
        isDead = false;

    }


}
