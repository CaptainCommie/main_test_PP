using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D body;
    private BoxCollider2D box_collider;
    [SerializeField] private LayerMask ground_layer;
    [SerializeField] private float speed;       //this affects the speed of vertical movement
    [SerializeField] private float jump_power;      //this affects the height of the jump
    [SerializeField] private int extra_jumps_count;      //this is how many extra jumps a player has
    [SerializeField] private float fall_speed;      //this affects the speed at the character falls when down key is pressed
    
    private int extra_jumps;
    
    private void Awake() 
    {
        //grab references for rigidboy and animator components from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        box_collider = GetComponent<BoxCollider2D>();
    }

    private void Update() 
    {
        //this stores the value of the horizontal movement
        float horizontal_input = Input.GetAxis("Horizontal");
        //This moves the player is a horizontal direction
        body.velocity = new Vector2(horizontal_input * speed, body.velocity.y);
        
        //Set the animation parameters
        anim.SetBool("running", horizontal_input != 0);
        anim.SetBool("grounded", is_grounded());
        
        //This changes the direction the player is facing based of horizontal movement
        if(horizontal_input > 0.01f) 
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(horizontal_input < -0.01f) 
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //Makes the player jump whenever the space key is pressed once
        if(Input.GetKeyDown("space")) 
        {
            Jump();
        }

        //sets variables if the character is grounded
        if(is_grounded())
        {
            extra_jumps = extra_jumps_count;
        }
        
        //controls the aerial movement
        if(Input.GetKey(KeyCode.S))
        {
            if(!is_grounded())
            {
                body.velocity = new Vector2(body.velocity.x, -speed * fall_speed);
            }
        }
    }

    //checks whether the player has additional extra jumps and then jumps if the player has additional jumps
    private void Jump() 
    {
        if(extra_jumps > 0)
        {
            body.velocity = new Vector2(body.velocity.x, jump_power);
            anim.SetTrigger("jump");
            
            //decrements the amount of extra jumps so a player cannot jump infinitey
            extra_jumps--;
        }
    }
              
    
    //checks whether the player is grounded and returns a boolean
    private bool is_grounded() 
    {
        RaycastHit2D ray_cast_hit = Physics2D.BoxCast(box_collider.bounds.center, box_collider.bounds.size, 0, Vector2.down, 0.1f, ground_layer);
        return ray_cast_hit.collider != null;
    }
}
