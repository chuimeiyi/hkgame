using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class playerMovement : MonoBehaviour
{

    public Rigidbody2D rb;

    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Jumping")]
    public float jumpPower = 5f;

    [Header("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask groundLayer;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    Animator animator;
    int magnitude = 0;
    int idle = 0;
    private bool isGrounded;
    public string items;
    public colC process;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = rb.GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer);

        float horizontalMovement = Input.GetAxis("Horizontal");

        if (Input.GetKey(right))   //right
        {
            animator.SetFloat("magnitude", 1);
            animator.SetFloat("idle", 1);
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

            magnitude = 1;
            idle = 0;
        }
        else if (Input.GetKey(left))   //left
        {
            animator.SetFloat("magnitude", 2);
            animator.SetFloat("idle", 1);
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);

            magnitude = 2;
            idle = 0;
        }
        else if (magnitude > 1 || idle > 1)
        {     //idle for each right, left
            animator.SetFloat("magnitude", magnitude);
            animator.SetFloat("idle", idle);
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else
        {
            animator.SetFloat("magnitude", -1);
            animator.SetFloat("idle", -1);
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKeyDown(jump) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(items))
        {
            process.itemCount++;
            Destroy(collision.gameObject);
        }


    }

}