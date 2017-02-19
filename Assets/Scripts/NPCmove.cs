using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCmove : MonoBehaviour {

    Animator anim;
    public float movespeed;
    public float jumpheight;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
    
        if (Input.GetKey(KeyCode.P))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpheight);
        }
        if (Input.GetKey(KeyCode.K))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-movespeed, 0);
        }
        if (Input.GetKey(KeyCode.L))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(movespeed, 0);
        }

    }
}