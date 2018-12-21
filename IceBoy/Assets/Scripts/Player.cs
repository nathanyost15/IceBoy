using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private enum States {Idle, Walking, Jumping, Falling, Grounded};
    private States activeState;
    private float walkSpeed, jumpForce;
    void Start()
    {
        activeState = States.Idle;
        walkSpeed = .5f;
        jumpForce = 2000f;
    }

    // Update is called once per frame
    void Update()
    {          
        switch(activeState)
        {
            case States.Idle:
            case States.Walking:
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    transform.position += new Vector3(walkSpeed * Time.deltaTime, 0, 0);
                    activeState = States.Walking;
                }
                else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.position += new Vector3(-1 * walkSpeed * Time.deltaTime, 0, 0);
                    activeState = States.Walking;
                }
                else
                {
                    activeState = States.Idle;
                }

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
        }        
    }
}
