using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    private float moveInput;

    static readonly int walkAnim = Animator.StringToHash("Walking Right");
    static readonly int idleAnim = Animator.StringToHash("Idle2");
    static readonly int jumpAnim = Animator.StringToHash("Jump");

    private Rigidbody2D rb;
    public Animator animator;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    // Use this for initialization
    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

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
        {
            animator.Play(jumpAnim);
        }
        else
        {
            if (Mathf.Abs(moveInput) > 0.01f)
            {
                animator.Play(walkAnim);
                print("walking");
            }
            else
            {
                animator.Play(idleAnim);
                print("not walking");
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rb.velocity = Vector2.up * jumpForce;
                animator.Play(jumpAnim);
            }
            else if (extraJumps > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                extraJumps--;
                animator.Play(jumpAnim);
            }
        }
    }

    void FLip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
    