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

        if(Input.GetKey(KeyCode.W) && grounded) {
            Jump();
        }
        else if(Input.GetKey(KeyCode.UpArrow) && grounded) {
            Jump();
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

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "ground") {
            grounded = true;

        }
    }
    
    


    
}
