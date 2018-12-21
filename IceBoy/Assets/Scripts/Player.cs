using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private enum States {idle};
    private States activeState;    
    private float idleAnimSpeed;
    private int idleHash;
    private Animator anim;
    void Start()
    {
        idleHash = Animator.StringToHash("Test1");
        Debug.Log(idleHash);
        //activeState = States.idle;
        anim = GetComponent<Animator>();
        //anim.speed = 2f;
        anim.SetTrigger(idleHash);
    }

    // Update is called once per frame
    void Update()
    {   
        /*switch(activeState)
        {
            case States.idle:
                Debug.Log("Hello");
                anim.SetTrigger(idleHash);
                break;
        }*/
    }
}
