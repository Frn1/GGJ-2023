using UnityEngine;

public class Jump2D : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float airControl = 1f;
    private Rigidbody2D rb;
    private bool isGrounded = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
}