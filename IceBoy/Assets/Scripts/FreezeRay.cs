﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeRay : MonoBehaviour
{
    private SpriteRenderer iceBoySprite, sprite;
    private Vector3 rightPosition, leftPosition;
    private GameObject particleSys;    
    private ParticleSystem p;

    public Sprite freezeRayIdle, freezeRayFiring;
    void Start()
    {
        leftPosition = new Vector3(-0.069f, 0.004999995f, 0);
        rightPosition = new Vector3(0.06800008f, 0.004999995f, 0);

        // Get handle to Player spriterenderer
        iceBoySprite = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();

        // Get handle to spriterenderer on this object
        sprite = gameObject.GetComponent<SpriteRenderer>();

        // Get handle to particle effect system
        particleSys = GameObject.Find("FreezeRayParticleSys");
        p = particleSys.GetComponent<ParticleSystem>();
    }
    
    void Update()
    {
        // Check if Freezegun is active
        if (Input.GetMouseButton(0))
        {
            if (!p.isPlaying)
            {     
                sprite.sprite = freezeRayFiring;
                p.Play();
            }
        }
        else
        {
            if (p.isPlaying)
            {
                sprite.sprite = freezeRayIdle;
                p.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            }
        }

        if (iceBoySprite.flipX)
        {
            // Move gun position
            transform.position = transform.parent.position + leftPosition;
            particleSys.transform.position = transform.parent.position + leftPosition;            
            particleSys.transform.rotation = Quaternion.Euler(180f, 90f, 0f);
            
            sprite.flipX = true;
        }
        else
        {
            // Move gun position
            transform.position = transform.parent.position + rightPosition;
            particleSys.transform.position = transform.parent.position + rightPosition;
            particleSys.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            sprite.flipX = false;
        }

        
    }
}
