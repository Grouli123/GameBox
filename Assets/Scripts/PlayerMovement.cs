using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{     
    [Header("Movement vars")]   
    [SerializeField] private float _jumpForce;
    [SerializeField] private bool _isGrounded = false;
    public static float speed = 0.6f;

    [Header("Settings")]
    [SerializeField] private Transform _groundColliderTransform;
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private LayerMask _groundMask;    
    [SerializeField] private Animator _animator;

    [Header("Scripts")]
    [SerializeField] private HeroDeath heroDeath;
    private Rigidbody2D _rb;    
    private AudioSource _jumpSound;
    private bool facingRight;
    private bool canDoubleJump;
    public float jumpOffset; 

    [SerializeField] private PlayerSettings _playerSettings;


    private Vector3 respawnPoint;

    private void Start() 
    {
        _jumpSound = GetComponent<AudioSource>();
        _animator.GetComponent<Animator>();
        
        _playerSettings.GetComponent<PlayerSettings>();

        respawnPoint = transform.position;
    }
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        facingRight = true;
    }

    private void FixedUpdate()
    {
        Vector3 _overlapCirrcleTransform = _groundColliderTransform.position;
        _isGrounded = Physics2D.OverlapCircle(_overlapCirrcleTransform, jumpOffset, _groundMask);
    }

    private void Update() 
    {

    }

    public void Move(float direction, bool isJumpButtonPressed)
    {
                   
        if(isJumpButtonPressed)
        {
            _animator.SetBool("IsJump", true);  
            Jump();
        }
        else
        {
            if(_isGrounded == true)
                _animator.SetBool("IsJump", false);  
        }
            
        if (!facingRight && direction > 0)
        {
            facingRight = !facingRight;
            transform.Rotate(0f, 180f, 0f); 
        }
        else if (facingRight && direction < 0)
        {
            facingRight = !facingRight;
            transform.Rotate(0f, 180f, 0f);
        }

        if(Mathf.Abs(direction) > 0.01f)
        {
            _animator.SetBool("IsRun", true);
            HorizontalMovement(direction);
        }
        else
        {
            _animator.SetBool("IsRun", false);
        }

        if(_isGrounded == false)
        {
            // _animator.SetBool("IsFall", true);
        }
        else
        {
            // _animator.SetBool("IsFall", false);
        }
    }

    private void Jump()
    {
        if(_isGrounded)
        {
            canDoubleJump = true;
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);               
            //_jumpSound.Play();    
        }
        else
        {
            if(canDoubleJump)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);   
                canDoubleJump = false;
            }
        }
    }

    private void HorizontalMovement(float direction)
    {
        _rb.velocity = new Vector2(_curve.Evaluate(direction) * speed,_rb.velocity.y);
    }

    public void OnAnimator(string name, bool active)
    {
        _animator.SetBool(name, active);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "FallDetector")
        {
            transform.position = respawnPoint;
        }
        else if (collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        } 
    }

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public void OnClickContinueOnDeath()
    {
        if (_playerSettings.Hp < 0 & _playerSettings.Cassete > 0)
        {
            heroDeath.PanelDeath(false);
            transform.position = respawnPoint;
            _playerSettings.Hp = 10;
            _playerSettings.Cassete -= 1;
        }
    }
}