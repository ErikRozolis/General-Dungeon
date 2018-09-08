using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour {

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		if(rb.velocity.x < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
        if (rb.velocity.y <= 0)
        {
            sr.flipY = false;
        }
        else
        {
            sr.flipY = true;
        }
    }
}
