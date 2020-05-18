using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents movement behaviours
public class Movement : MonoBehaviour {

    //SINGLETON
    private static Movement singleton;

    public float speed;                 //Floating point variable to store the player's movement speed.

    private SpriteRenderer spriteR;     //Sprite Renderer for flipping image on X axis.
    private Rigidbody2D rb2d;           //Store a reference to the Rigidbody2D component required to use 2D Physics.

    // Animator

    public Animator animaton_run;

    private void Awake()
    {
        //SINGLETON
        if (singleton != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();

        //Singleton.instance.character = GameObject.Find("Character");
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        
        animaton_run.SetFloat("Speed", Mathf.Abs(moveHorizontal));
        //Flip image on X axis when moving left
        if (moveHorizontal < 0)
        {
            spriteR.flipX = true;
        }
        else
        {
            spriteR.flipX = false;
        }

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce(movement * speed);
    }
}