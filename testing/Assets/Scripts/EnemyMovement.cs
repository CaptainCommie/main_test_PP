using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D body;
    private BoxCollider2D box_collider;
    [SerializeField] private float enemy_speed;
    [SerializeField] private float enemy_jump_power;
    private float horizontal_movement;
    public Transform player;
    private float movement_x;
    private float movement_y;
    void Awake()
    {
        //grabs the references to the components
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    
    void Update()
    {
        movement_x = player.position.x - transform.position.x;
        body.velocity = new Vector2(enemy_speed * movement_x , body.velocity.y);

        
        movement_y = player.position.y - transform.position.y;
        body.velocity = new Vector2(body.velocity.x, enemy_speed * 2 * movement_y);
        
        
        //horizontal_movement is the x axis movement
        float horizontal_movement = body.velocity.x;
        
        //sets the animation parameters so moving is true when the enemy is moving
        anim.SetBool("moving", horizontal_movement != 0);

        //moves the enemy based on the enemy_speed variable
        body.velocity = new Vector2(body.velocity.x, body.velocity.y);
        
    
        //changes the way that the enemy is facing depending on the horizontal
        if (horizontal_movement > 0.1f) 
        {
            //the seemingly weird numbers are because I had to scale the enemy up to the right size and this was the correct scale
            transform.localScale = new Vector3(3.80579996f, 4.18227768f, 1);
        }
        else if (horizontal_movement < -0.01f)
        {
            transform.localScale = new Vector3(-3.80579996f, 4.18227768f, 1);
        }
    }
}
