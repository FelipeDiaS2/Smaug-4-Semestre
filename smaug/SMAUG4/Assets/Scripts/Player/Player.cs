using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Components:")]
    [SerializeField] private Rigidbody rb;
    
   
    [Header("Physics:")]
    public float speed;
    [SerializeField] private float jumpForce;
   
    private Vector2 moveInput;

    public SpriteRenderer sprite;

    private Item[] item;
    private InventoryManager inventoryManager;

    public Animator animator;

    private string olhando = "baixo";

    public string currentState;
    const string IDLE_FACING = "Idle_facing";
    const string IDLE_BACKWARDS = "Idle_backwards";
    const string RUN_FACING = "Run_facing";
    const string RUN_BACKWARDS = "Run_backwards";

    void Start()
    {

    }

    
    void Update()
    {
    
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        rb.velocity = new Vector3(speed * moveInput.x, rb.velocity.y, speed * moveInput.y);

        if (moveInput.x > 0)
        {
            sprite.flipX = true;
        }
        else if (moveInput.x < 0) 
        { 
            sprite.flipX = false;
        }
        /*if(moveInput.y > 0)
        {
            ChangeAnimationState(IDLE_BACKWARDS);
            print("parada cima");
        }else if (moveInput.y < 0)
        {
            ChangeAnimationState(IDLE_FACING);
            print("parada baixo");
        }
        */
        
        if (moveInput.x != 0 && moveInput.y < 0 || moveInput.y < 0)
        {
            ChangeAnimationState(RUN_FACING);
            print("correno baixo");
            olhando = "baixo";
        }
        else if(moveInput.x != 0 && moveInput.y > 0 || moveInput.y > 0)
        {
            ChangeAnimationState(RUN_BACKWARDS);
            print("correno cima");
            olhando = "cima";
        }
        else if(moveInput.x != 0)
        {
            ChangeAnimationState(RUN_FACING);
            print("joga de ladin");
            olhando = "baixo";
        }
        else if(moveInput.x == 0 && moveInput.y == 0 && olhando == "baixo") 
        { 
            ChangeAnimationState(IDLE_FACING);
        }else if (moveInput.x == 0 && moveInput.y == 0 && olhando == "cima")
        {
            ChangeAnimationState(IDLE_BACKWARDS);
        }


    }

    void ChangeAnimationState(string newState)
    {
        //Stop animation
        if (currentState == newState) return;

        //Play new animation
        animator.Play(newState);

        //Update
        currentState = newState;
    }
}
