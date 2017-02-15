using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour {

    Animator anim;
    public float movespeed;
    public float jumpheight;
    int jump = Animator.StringToHash("Jump");
    int right = Animator.StringToHash("Right Player");
    int left = Animator.StringToHash("Left player");

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger(jump);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpheight);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetTrigger(left);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-movespeed, 0);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            anim.SetTrigger(right);
            GetComponent<Rigidbody2D>().velocity = new Vector2(movespeed, 0);
        }
    }
}