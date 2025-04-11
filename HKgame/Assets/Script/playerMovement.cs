using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    [Header("Movement")]
    public float moveSpeed = 5f;
    float horizontalMovement;

    [Header("Jumping")]
    public float jumpPower = 5f;

    [Header("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask groundLayer;

    Animator animator;
    int magnitude = 0;
    int idle = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = rb.GetComponent<Animator>();
    }

    void Update()
    {
        rb.velocity = new Vector2(horizontalMovement * moveSpeed, rb.velocity.y);

        // Check if the vertical velocity is greater than or less than zero
        if (Input.GetKey(KeyCode.D))   //right
        {
            animator.SetFloat("magnitude", 1);
            animator.SetFloat("idle", 1);

            magnitude = 1;
            idle = 0;
        }
        else if (Input.GetKey(KeyCode.A))   //left
        {
            animator.SetFloat("magnitude", 2);
            animator.SetFloat("idle", 1);

            magnitude = 2;
            idle = 0;
        }
        else if (magnitude > 1 || idle > 1 ) {     //idle for each right, left
            animator.SetFloat("magnitude", magnitude);
            animator.SetFloat("idle", idle);
        }
        else {
            animator.SetFloat("magnitude", -1);   
            animator.SetFloat("idle", -1);
        }
    }

    public void Move(InputAction.CallbackContext context) {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }

    public void jump(InputAction.CallbackContext context){
        if (isGrounded()) {
            if (context.performed)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            }
            else if (context.canceled)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }

        }
    }
    private bool isGrounded() {
        if (Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer)) { 
            return true;
        }
        return false;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
    }

}
