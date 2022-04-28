using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D body;
    private BoxCollider2D box_collider;
    [SerializeField] private float enemy_speed;
    [SerializeField] private float enemy_jump_power;


    
    // Start is called before the first frame update

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    
    void Update()
    {
        
    }
}
