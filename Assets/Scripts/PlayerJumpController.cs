using MoreMountains.Feedbacks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJumpController : MonoBehaviour
{
    [SerializeField] private float jumpForce         = 26.5f;
    [SerializeField] private float airControl        = 1f;
    [SerializeField] private float fallMultiplier    = 3f;
    [SerializeField] private float lowJumpMultiplier = 15f;
    [SerializeField] private float groundCheckRadius = 0.2f;
    
    public float jumpReducer;
    public bool isGrounded;

    public Transform groundCheck;
    public LayerMask whatIsGround;
    
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private PlayerSounds sounds;
    private SpriteRenderer _spriteRenderer;

    [Header("Player Feedbacks")] 
    [SerializeField] private MMFeedbacks _jumpFeedback;
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        jumpReducer = 1;
        sounds=GetComponent<PlayerSounds>();
    }

    private void Update()
    {
        _animator.SetBool("isGrounded", isGrounded);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        
        if (_rigidbody2D.velocity.y < 0)
        {
            _rigidbody2D.velocity += Vector2.up * (Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime);
        }
        
        else if (_rigidbody2D.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            _rigidbody2D.velocity += Vector2.up * (Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            _rigidbody2D.velocity = Vector2.up * (jumpForce * jumpReducer);

            GameManager.instance.jumps++;
            
            _jumpFeedback.PlayFeedbacks();
            //sounds.JumpAudio();
            //isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        
        if (!isGrounded)
        {
            if (Mathf.Abs(_rigidbody2D.velocity.x) <= 10)
            {
                _rigidbody2D.velocity += new Vector2(horizontal * airControl, 0);
            }
            
            else
                _rigidbody2D.velocity -= new Vector2(horizontal * airControl, 0);
        }

        if (horizontal < -0.2)
        {
            _spriteRenderer.flipX = true;
        }
        
        else if (horizontal > 0.2)
        {
            _spriteRenderer.flipX = false;
        }
    }
}