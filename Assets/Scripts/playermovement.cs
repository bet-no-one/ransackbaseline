using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour {

    Animator anim;
    public float movespeed;     // variable exposed to unity to adjust move left / right speed
    public float jumpheight;    // variable exposed to unity to adjust jump up speed
    public float debounceTime;  // used to de-bounce the keys
	public float lastStep;		// used to de-bounce the keys
    public bool onLadder;       // True if on Ladder 
    public Vector2 gravitySetting; // Stores Gravity setting
    int jump = Animator.StringToHash("Jump");           // reference to Jump trigger
    int right = Animator.StringToHash("Right Player");  // reference to player move right trigger
    int left = Animator.StringToHash("Left player");    // referrence to player move left trigger
    int idle = Animator.StringToHash("idle player");    // reference to player idle trigger

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();  // when programe starts get the animator object
                                          // Get gravity setting
        gravitySetting = Physics2D.gravity;  // store current Gravity

    }



    // Update is called once per frame
    void Update()
    {
        bool KeyPress = false;              // Used to determine when to send the idle trigger
        Vector2 oldVelocity;


        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);


        if (Input.GetKey(KeyCode.Space))    // Jump actions
        {
                // reset de-bounce timer
            KeyPress = true;                //
            anim.SetTrigger(jump);
            oldVelocity = GetComponent<Rigidbody2D>().velocity;
            GetComponent<Rigidbody2D>().velocity = new Vector2(oldVelocity.x, jumpheight);
        }
        else if (Input.GetKey(KeyCode.Z))        // Left actions
        {
            lastStep = Time.time;           // reset de-bounce timer
            KeyPress = true;
            anim.SetTrigger(left);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-movespeed, 0);
        }
        else if (Input.GetKey(KeyCode.X))        // Right actions
        {
            lastStep = Time.time;           // reset de-bounce timer
            KeyPress = true;
            anim.SetTrigger(right);         // trigger animation for right
            GetComponent<Rigidbody2D>().velocity = new Vector2(movespeed, 0);
        }

        // If no keys pressed and debounce time exceeded
        if ((KeyPress == false))    // no keypress actions after a debounce time
        {
            lastStep = Time.time; 
            // reset de-bounce timer
            anim.SetTrigger(idle);

        }

    }


    // Event triggered when player is in colision with swag
    void OnTriggerStay2D(Collider2D other)
    {
        // If in colision with Swag
        if (other.gameObject.CompareTag("SWAG bag")) {

            // We can now pickup the swag if "L" pressed
            if (Input.GetKey(KeyCode.L))
            {
                // todo: add points
                Destroy(other.gameObject);
            }
        }

        // If in colision with Ladder
        if (other.gameObject.CompareTag("Ladder"))
        {
            // If K pressed then go up ladder
            if (Input.GetKey(KeyCode.K))
            {
                // Go up ladder
                onLadder = true;
                // turn off gravity
                Physics2D.gravity = new Vector2(0, 0);
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, movespeed);
                // stop collisions with platforms when on ladder
                Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Platform"), LayerMask.NameToLayer("Player"),true);
            }

            // If M pressed then go up ladder
            if (Input.GetKey(KeyCode.M))
            {
                // todo: go down
                onLadder = true;
                // turn off gravity
                Physics2D.gravity = new Vector2(0, 0);
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -movespeed);
                // stop collisions with platforms when on ladder
                Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Platform"), LayerMask.NameToLayer("Player"), true);
            }

        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Actions taken when player leaves the Ladder
        if (other.gameObject.CompareTag("Ladder"))
        {
            onLadder = false;
            // re-enable collisions with platforms
            // stop collisions with platforms when on ladder
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Platform"), LayerMask.NameToLayer("Player"), false);
            // turn on gravity
            Physics2D.gravity = gravitySetting;


        }

    }

}



