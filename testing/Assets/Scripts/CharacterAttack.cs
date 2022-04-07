using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] private float attack_cooldown;
    private Animator anim;
    private CharacterMovement character_movement;
    private float cooldown_timer; 


    private void Awake()
    {
        //retreives references for each of the components
        anim = GetComponent<Animator>();
        character_movement = GetComponent<CharacterMovement>();
    }

    private void Update()
    {
        if(Input.GetMouseButton(0) && cooldown_timer > attack_cooldown)
        {
            Attack();
        }

        cooldown_timer = cooldown_timer + Time.deltaTime;
    }

    private void Attack() 
    {
        //sets the attack animation
        anim.SetTrigger("attack");
        
        //resets the cooldown timer
        cooldown_timer = 0;
    }
}