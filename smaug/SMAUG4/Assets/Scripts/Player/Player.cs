using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Components:")]
    [SerializeField] private Rigidbody rb;


    [Header("Physics:")]
    public float speed;
    [SerializeField] private float jumpForce;

    private Vector2 moveInput;

    private Item[] item;
    private InventoryManager inventoryManager;

    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public AudioSource PassosSFX;

    private bool canPlayPasso = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        animator.SetFloat("moveX", Mathf.Abs(moveInput.x));
        animator.SetFloat("moveY", moveInput.y);

        if (moveInput.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveInput.x < 0)
        {
            spriteRenderer.flipX = false;
        }

        if (rb.velocity.magnitude != 0 && canPlayPasso)
        {
            PassosSFX.Play();
            canPlayPasso = false;
            Invoke("ResetCanPlayPasso", 1f); // Altera o intervalo no segundo argumento
        }
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

    private void ResetCanPlayPasso()
    {
        canPlayPasso = true;
    }
}