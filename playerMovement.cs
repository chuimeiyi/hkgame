using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMovement : MonoBehaviour
{
    public GameObject[] groundCheckPods;
    public bool lockPlayer = false;

    public Rigidbody2D rb;

    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Jumping")]
    public float jumpPower = 20f;
    private float jumpTimeToApex = 5f;
    private bool _isJumpCut;
    float jumpCutGravityMult = 40f;
    public float LastOnGroundTime;
    public float LastPressedJumpTime;

    [Header("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask groundLayer;

    [Header("Gravity")]
    public float baseGravity = 1f;
    public float maxFallSpeed = 15f;
    public float fallSpeedMultiplier = 1f;

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
        
        LastOnGroundTime -= Time.deltaTime;

        LastPressedJumpTime -= Time.deltaTime;

        if (LastOnGroundTime > 0) {
            _isJumpCut = false;
        }
        else { 
            _isJumpCut = true;
        }

        /*if (_isJumpCut)
        {
            rb.gravityScale(0);
        }
            
            (_isJumpCut == true && rb.velocity.y < 0) {
            rb.gravityScale = rb.gravityScale * jumpCutGravityMult;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, maxFallSpeed));
        }*/

        Debug.Log("GroundCheckPods length: " + (groundCheckPods != null ? groundCheckPods.Length.ToString() : "null"));

        isGrounded = Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer);

        float horizontalMovement = Input.GetAxis("Horizontal");

        if (!lockPlayer)
        {
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
                // rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                Jump();
            }
        }

        Gravity();

    }
    
    private void Gravity() { 
        if(rb.velocity.y < 0) {
            rb.gravityScale = baseGravity + fallSpeedMultiplier;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -maxFallSpeed));
        }
        else { 
            rb.gravityScale = baseGravity;    
        }
    }
    private void Jump()
    {
        //Ensures we can't call Jump multiple times from one press
        LastPressedJumpTime = 0;
        LastOnGroundTime = 0;

        jumpPower = Mathf.Abs(baseGravity) * jumpTimeToApex;
        float force = jumpPower;
        if (rb.velocity.y < 0)
            force -= rb.velocity.y;

        rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
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