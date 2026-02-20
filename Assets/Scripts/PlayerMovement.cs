using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Speed")]
    public float speed;

    [Header("Jump")]
    public float jumpForce;
    private float moveInput;

    static readonly int walkAnim = Animator.StringToHash("Walking Right");
    static readonly int idleAnim = Animator.StringToHash("Idle2");
    static readonly int jumpAnim = Animator.StringToHash("Jump");
    static readonly int wallJumpAnim = Animator.StringToHash("WallJump");

    private Rigidbody2D rb;

    [Header("Animator")]
    public Animator animator;

    private bool facingRight = true;

    private bool isGrounded;

    [Header("Ground")]
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;

    [Header("Double Jump")]
    public int extraJumpsValue;

    private bool isTouchingWall = false;
    private bool hasWallJumped = false;

    [Header("Wall Jump")]
    public float wallJump = 10f;
    public Transform wallCheck;
    public LayerMask whatIsWall;
    public float wallCheckRadius;

    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        isTouchingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (!facingRight && moveInput > 0)
            FLip();
        else if (facingRight && moveInput < 0)
            FLip();
    }

    void Update()
    {
        if (isGrounded && rb.velocity.y <= 0.01f)
            extraJumps = extraJumpsValue;

        if (!isGrounded)
            animator.Play(jumpAnim);
        else
        {
            if (Mathf.Abs(moveInput) > 0.01f)
                animator.Play(walkAnim);
            else
                animator.Play(idleAnim);
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rb.velocity = Vector2.up * jumpForce;
                animator.Play(jumpAnim);
                hasWallJumped = false;
            }
            else if (isTouchingWall && !hasWallJumped)
            {
                hasWallJumped = true;
                float pushDirection = facingRight ? -1 : 1;
                rb.velocity = new Vector2(pushDirection * wallJump, jumpForce);
                animator.Play(jumpAnim);
            }
            else if (extraJumps > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                extraJumps--;
                animator.Play(jumpAnim);
            }
        }

        if (!isTouchingWall)
            hasWallJumped = false;
    }

    void FLip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}