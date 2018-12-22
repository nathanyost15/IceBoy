using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeRay : MonoBehaviour
{
    private SpriteRenderer iceBoySprite, sprite;
    private Vector3 rightPosition, leftPosition;
    void Start()
    {
        leftPosition = new Vector3(-0.069f, 0.004999995f, 0);
        rightPosition = new Vector3(0.06800008f, 0.004999995f, 0);
        iceBoySprite = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        sprite = gameObject.GetComponent<SpriteRenderer>();        
    }
    
    void Update()
    {
        if(iceBoySprite.flipX)
        {
            transform.position = transform.parent.position + leftPosition;
            sprite.flipX = true;
        }
        else
        {
            transform.position = transform.parent.position + rightPosition;
            sprite.flipX = false;
        }
    }
}
