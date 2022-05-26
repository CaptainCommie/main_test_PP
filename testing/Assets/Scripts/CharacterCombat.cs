using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    [SerializeField] private float attack_cooldown;
    private Animator anim;
    private CharacterMovement character_movement;
    private BoxCollider2D box_collider;
    private Rigidbody2D body;
    [SerializeField] private float cooldown_timer; 
    [SerializeField] private float attack_damage;
    [SerializeField] private int character_health;
    [SerializeField] new Vector3 respawn_point;


    private void Awake()
    {
        //retreives references for each of the components
        anim = GetComponent<Animator>();
        character_movement = GetComponent<CharacterMovement>();
        box_collider = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetMouseButton(0) && cooldown_timer > attack_cooldown)
        {
            Attack();
        }

        cooldown_timer = cooldown_timer + Time.deltaTime;


        if(Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }
    }

    private void Attack() 
    {
        //sets the animation parameters
        anim.SetTrigger("attack");
        
        //resets the cooldown timer and needs to be at the end.
        cooldown_timer = 0;
    }

    private void Respawn()
    {
        body.position = respawn_point;
        body.velocity = new Vector3(0, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            character_health = character_health - 1;
        }
    }



}