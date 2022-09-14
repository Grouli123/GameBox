using UnityEngine;
using System.Collections;
public class EnemyController : MonoBehaviour
{    
    [SerializeField] private GameObject _bullet;   

    [SerializeField] private Transform _player;
    [SerializeField] private Transform _shootPos;
    [SerializeField] private Transform _groundCheckPosition;
    [SerializeField] private Transform _originalPoint;
    
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private Collider2D _bodyCollider;

    [SerializeField] private LayerMask _groundLayer;

    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _range;
    public float timeBTWShoots;
    [SerializeField] private float _shootSpeed;

    [SerializeField] private string _groundLayerName;
    [SerializeField] private string _objectCollisionTag;
    [SerializeField] private string _playerCollisionTag;

    [SerializeField] private AudioSource shootSound;

    [SerializeField] private Animator _anim;


    
    private float _castDist;

    private bool _mustTurn;
    private bool _canShot;
    private bool _mustPatrol;
    private bool _isAgro = false;

    private void Start()
    {
        _mustPatrol = true;
        _canShot = true;
    }

    private void Update()
    {

        if (_mustPatrol)
        {
            Patrol();
        }

        if (CanSeePlayer(_range))
        {
            _isAgro = true;
        }
        else
        {
            _isAgro = false;
        }

        if (_isAgro)
        {
            if (_player.position.x > transform.position.x && transform.localScale.x < 0
            || _player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                Flip();
            }

            EnemyStay();                
        }
        else
        {
            _mustPatrol = true;                
        }
    }

    private bool CanSeePlayer(float distance)
    {
        bool val = false;
        _castDist = distance;

        Vector2 endPos = _shootPos.position + Vector3.right * _castDist;
        RaycastHit2D hit = Physics2D.Linecast(_shootPos.position, endPos, 1 << LayerMask.NameToLayer(_groundLayerName));

        if (hit.collider != null)
        { 
            if (!hit.transform.gameObject.CompareTag(_objectCollisionTag))
            {
                Debug.DrawLine(_shootPos.position, hit.point, Color.yellow);    
            }
            else
            {
                if (hit.collider.gameObject.CompareTag(_playerCollisionTag))
                {
                    val = true;
                    EnemyStay();
                    
                    if(_canShot)
                    StartCoroutine(Shoot());                    
                    _anim.SetBool("Idle", true); 
                }
                else
                {
                    val = false;
                    _anim.SetBool("Idle", false); 

                    
                    if(_canShot)
                    StartCoroutine(Shoot());
                }

                Debug.DrawLine(_shootPos.position, hit.point, Color.yellow);       
            }
        }
        else
        {            
            Debug.DrawLine(_shootPos.position, endPos, Color.blue);
        }

        return val;
    }

    private void EnemyStay()
    {
        _mustPatrol = false;
        _rb.velocity = Vector2.zero;                
    }

    private void FixedUpdate()
    {
        if (_mustPatrol)
        {       

            _mustTurn = !Physics2D.OverlapCircle(_groundCheckPosition.position, 0.1f, _groundLayer);
        }
    }

    private void Patrol()
    {
        if (_mustTurn || _bodyCollider.IsTouchingLayers(_groundLayer))
        {   
            // _rb.bodyType = RigidbodyType2D.Static;
            // EnemyStay();
            // _anim.SetBool("Idle", true);  
            // StartCoroutine(Idle());     
            Flip();     
        }

        _rb.velocity = new Vector2(_walkSpeed * Time.fixedDeltaTime, _rb.velocity.y);
    }

    private void Flip()
    {
        _mustPatrol = false;                
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        _walkSpeed *= -1;
        _range *= -1;
        Destroy(_bullet);
        _mustPatrol = true;
    }

    private IEnumerator Shoot()
    {
        _canShot = false;
        yield return new WaitForSeconds(timeBTWShoots);
        GameObject newBullet = Instantiate(_bullet, _shootPos.position, Quaternion.identity);
        shootSound.Play();
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(_shootSpeed * _walkSpeed * Time.fixedDeltaTime, 0f);
        _canShot = true;
    }

    private IEnumerator Idle()
    {
        yield return new WaitForSeconds(1);
        _anim.SetBool("Idle", false); 
        _rb.bodyType = RigidbodyType2D.Dynamic;     
    }

    public float WalkSpeed
    {
        get { return _walkSpeed; }
        set { _walkSpeed = value; }
    }

    public float Range
    {
        get { return _range; }
        set { _range = value; }
    }
}