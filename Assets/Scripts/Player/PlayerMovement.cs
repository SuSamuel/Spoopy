using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveInput;

    private Animator animator;
    private SpriteRenderer _renderer;

    public bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        facingRight = moveInput.x == 0 ? facingRight : moveInput.x > 0;

        if(moveInput == Vector2.zero) {
            animator.SetBool("idle", true);
        } else {
            animator.SetBool("idle", false);
        }
        _renderer.flipX = !facingRight;

        rb.velocity = moveInput * moveSpeed;
    }
}
