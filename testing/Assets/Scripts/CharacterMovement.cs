using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D body;
    private bool grounded;      //checks whether the character is grounded
    [SerializeField] private float speed;       //this affects the speed of vertical movement
    [SerializeField] private float jump_power;      //this affects the height of the jump
    [SerializeField] private float max_jumps = 2;       //this is how many jumps the character can do
    private int jump_amount = 0;        //This relates to my double jumping mechanic
    


    //Awake is called when the script is initially run
    private void Awake() {
        //grab references for rigidboy and animator components from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    private void Update() {
        //this stores the value of the horizontal movement
        float horizontal_input = Input.GetAxis("Horizontal");
        //This is the code for horizontal movement and does not affect vertical movement
        body.velocity = new Vector2(horizontal_input * speed, body.velocity.y);
        

        //This changes the direction the player is facing based of horizontal movement
        if (horizontal_input > 0.01f) {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontal_input < -0.01f) {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //This is the code for the jumping mechanic
        if(Input.GetKey(KeyCode.W)) {
            if (jump_amount < max_jumps) {
                Jump();
            }        
        }
        else if(Input.GetKey(KeyCode.UpArrow)) {
            if (jump_amount < max_jumps) {
                Jump();
            }
        }
        
        
        //Set the animation parameters
        anim.SetBool("running", horizontal_input != 0);
        anim.SetBool("grounded", grounded);
    }

    
    private void Jump() {
        //This add jumping into the game when w or the up arrow are pressed
        body.velocity = new Vector2(body.velocity.x, jump_power);
        anim.SetTrigger("jump");
        grounded = false;
        jump_amount = jump_amount + 1;

    }

    private void OnCollisionEnter2D(Collision2D collision) {        //when the player is touching the ground, this is true
        if (collision.gameObject.tag == "ground") {
            grounded = true;
            jump_amount = 0;        //resets jump_amount to 1 when the player is grounded

        }
    }
    
    
// GRAVITY ORIGINALLY SET TO 7

    
}
