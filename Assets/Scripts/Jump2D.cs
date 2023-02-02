using UnityEngine;

public class Jump2D : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float airControl = 1f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float jumpReducer;
    private Rigidbody2D rb;
    public bool isGrounded = false;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask whatIsGround;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpReducer=1;
}

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (rb.velocity.y<0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }else if(rb.velocity.y> 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce*jumpReducer;
            //isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        if (!isGrounded)
        {
            if (Mathf.Abs(rb.velocity.x) <= 10)
            {
                rb.velocity += new Vector2(Input.GetAxis("Horizontal") * airControl, 0);
            }
            else
                rb.velocity -= new Vector2(Input.GetAxis("Horizontal") * airControl, 0);


        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    isGrounded = true;
    //}
}