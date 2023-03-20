using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    private bool isJumping = false;

    public bool FacingRight { get => facingRight; set => facingRight = value; }

    //Awake is called after all objects are initialized. called in a random order
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // will look for a component on this GameObject (what the script is attached to) of type Rigidbody2D.
    }

    // Update is called once per frame
    void Update()
    {
        //Get inputs
        ProcessInputs();

        //Animate
        Animate();
    }

    private void FixedUpdate()
    {

        Move();
    }
    private void ProcessInputs()
    {
        moveDirection = Input.GetAxis("Horizontal"); // Scale of -1 -> 1
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
    }
    private void Animate()
    { //animate 
        if (moveDirection > 0 && !FacingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && FacingRight)
        {
            FlipCharacter();
        }
    }
    private void Move()
    { //Move
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
        }
        isJumping = false;
    }

    private void FlipCharacter()
    {
        FacingRight = !FacingRight; //Inverse bool
        transform.Rotate(0f, 180f, 0f);
    }

    void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "MP")
            {
                transform.parent = col.transform;
            }
        }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "MP")
        {
            transform.parent = null;
        }
    }

    public void SpeedPowerUp()
    {
        StartCoroutine(PowerUpSpeed());
    }

    IEnumerator PowerUpSpeed()
    {
        moveSpeed = 9;
        yield return new WaitForSeconds(5);
        moveSpeed = 5;
    }
}
