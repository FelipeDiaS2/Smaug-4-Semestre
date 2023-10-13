using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Components:")]
    [SerializeField] private Rigidbody rb;
    
   
    [Header("Physics:")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
   
    private Vector2 moveInput;

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


    }
}
