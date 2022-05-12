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

    void Awake()
    {
        //grabs the references to the components
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    
    void Update()
    {
        //horizontal_movement is the x axis movement
        float horizontal_movement = body.velocity.x;
        
        anim.SetBool("running", horizontal_movement != 0);
        
        //moves the character to the right
        body.velocity = new Vector2(enemy_speed, body.velocity.y);
        
    }
}
