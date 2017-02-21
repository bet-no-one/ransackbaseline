using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCmove : MonoBehaviour {

    Animator anim;
    public float movespeed;
    public float jumpheight;
    public bool NPCgoingRight;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        NPCgoingRight = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (NPCgoingRight)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(movespeed, 0);  //change Velocity to left
        } else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-movespeed, 0);  //change Velocity to left

        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // if collision is not player
        if (other.gameObject.CompareTag("Player") == false)
        {
            if (NPCgoingRight)
            {
                NPCgoingRight = false;  // going left!!!!
                GetComponent<SpriteRenderer>().flipX = true;
            } else
            {
                NPCgoingRight = true;  // going right!!!!
                GetComponent<SpriteRenderer>().flipX = false;
            }

        }
    }

}