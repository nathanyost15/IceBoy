using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private enum States {Idle, Walking, Jumping, Falling, Grounded};
    private States activeState;
    private float walkSpeed, airSpeed, jumpForce;
    private SpriteRenderer sprite;
    void Start()
    {
        activeState = States.Idle;
        walkSpeed = .7f;
        airSpeed = walkSpeed - .2f;
        jumpForce = 10000f;
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        // State system
        switch(activeState)
        {
            case States.Idle:
            case States.Walking:
                // Move Right/Left on the screen
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    transform.position += new Vector3(walkSpeed * Time.deltaTime, 0, 0);
                    sprite.flipX = false;
                    activeState = States.Walking;
                }
                else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.position += new Vector3(-1 * walkSpeed * Time.deltaTime, 0, 0);
                    sprite.flipX = true;
                    activeState = States.Walking;
                }
                else
                {
                    activeState = States.Idle;
                }

                // Change state to a jump state
                if (Input.GetKey(KeyCode.Space))
                {                    
                    activeState = States.Jumping;                    
                }
                break;
            case States.Jumping:
                // Applies force
                Rigidbody2D rgb2d = gameObject.GetComponent<Rigidbody2D>();
                rgb2d.AddForce(new Vector2(0, jumpForce * Time.deltaTime));

                // Then change state to falling
                activeState = States.Falling;
                break;
            case States.Falling:
                // Air movement in horizontal direction
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    transform.position += new Vector3(airSpeed * Time.deltaTime, 0, 0);
                    sprite.flipX = false;
                }
                else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.position += new Vector3(-1 * airSpeed * Time.deltaTime, 0, 0);
                    sprite.flipX = true;
                }
                break;
            case States.Grounded:
                // Resets player to idle state to allow jumping again
                activeState = States.Idle;
                break;
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if falling to see if the player has touched the ground to allow jumping again
        switch(collision.transform.tag)
        {
            case "Ground":
                if (activeState == States.Falling)
                {
                    activeState = States.Grounded;
                }
                break;
            case "Platform":
                goto case "Ground";
        }
        
    }
}
