using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControllerTwo : MonoBehaviour
{
    [SerializeField] private GameObject _bullet; 

    [SerializeField] private GameObject[] _groundBoss;  
    [SerializeField] private SliderJoint2D[] _sliderJooint;
    [SerializeField] private SliderUp[] _sliderUp;

    [SerializeField] private DamageForBoss _damageForBoss;

    [SerializeField] private Transform _player;
    // [SerializeField] private Transform _shootPos;
    // [SerializeField] private Transform _groundCheckPosition;
    [SerializeField] private Transform _originalPoint;
    
    [SerializeField] private Transform _firepointSecond;
    
    // [SerializeField] private Rigidbody2D _rb;

    // [SerializeField] private Collider2D _bodyCollider;

    // [SerializeField] private LayerMask _groundLayer;

    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _range;
    [SerializeField] private float _timeBTWShoots;
    [SerializeField] private float _shootSpeed;

    [SerializeField] private string _groundLayerName;
    [SerializeField] private string _objectCollisionTag;
    [SerializeField] private string _playerCollisionTag;

    [HideInInspector] public Vector2 endPos;
    
    private float _castDist;

    private bool _mustTurn;
    private bool _canShot;
    private bool _mustPatrol;
    private bool _isAgro = false;

    public Transform pointForBulletOne;
    public Transform pointForBulletTwo;    
    public Transform pointForBulletThree;

    private float _timer;

    [HideInInspector] public Transform attackPoint;

    [SerializeField] private ParticleSystem _effect;


    private void Start()
    {
        _timer = 5f;
        
        _mustPatrol = true;
        _canShot = true;
        // _damageForBoss = GetComponent<DamageForBoss>();
    }

    private void Update()
    {
        attackPoint = _player;

        // _timer -= Time.deltaTime;

        // if (_timer <= 0f)
        // {
        //     _player = pointForBulletTwo;
        //     _timer = 5f;
        // }
        // else
        // {
        //     _player = pointForBulletOne;
        // }
        // if (_damageForBoss.lives <= 7)
        // {
        //     SecondState();
 
        // }

        // if (_damageForBoss.lives <= 5)
        // {
        //     ThirdState();
        // }
        // if (_mustPatrol)
        // {
        //     Patrol();
        // }

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
               // Flip();
            }

            EnemyStay();                
        }
        // else
        // {
        //     _mustPatrol = true;                
        // }
    }

    private bool CanSeePlayer(float distance)
    {
        bool val = false;
        _castDist = distance;

        Vector2 endPos = _player.position + Vector3.right * _castDist;
        RaycastHit2D hit = Physics2D.Linecast(_originalPoint.position, endPos, 1 << LayerMask.NameToLayer(_groundLayerName));

        if (hit.collider != null)
        { 
            if (!hit.transform.gameObject.CompareTag(_objectCollisionTag))
            {
                Debug.DrawLine(_player.transform.position, hit.point, Color.yellow);
            }
            else
            {
                if (hit.collider.gameObject.CompareTag(_playerCollisionTag))
                {
                    val = true;
                    EnemyStay();
                }
                else
                {
                    val = false;
                    EnemyStay();
                }

                Debug.DrawLine(_originalPoint.position, hit.point, Color.yellow);       
            }
        }
        else
        {            
            Debug.DrawLine(_originalPoint.position, endPos, Color.blue);
        }

        return val;
    }

    private void EnemyStay()
    {
      //  _mustPatrol = false;
//        _rb.velocity = Vector2.zero;
        if(_canShot)
        {
            StartCoroutine(Shoot());    
            // _timer = 5f;
        }            
    }

    // private void FixedUpdate()
    // {
    //     // if (_mustPatrol)
    //     // {
    //     //     _mustTurn = !Physics2D.OverlapCircle(_groundCheckPosition.position, 0.1f, _groundLayer);
    //     // }

    // }

    // private void Patrol()
    // {
    //     if (_mustTurn || _bodyCollider.IsTouchingLayers(_groundLayer))
    //     {
    //         Flip();     
    //     }

    //     _rb.velocity = new Vector2(_walkSpeed * Time.fixedDeltaTime, _rb.velocity.y);
    // }

    // private void Flip()
    // {
    //     _mustPatrol = false;                
    //     transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    //     _walkSpeed *= -1;
    //     _range *= -1;
    //     _mustPatrol = true;
    // }

    private IEnumerator Shoot()
    {
        
       // var Test = Vector3.MoveTowards(transform.position, _player.transform.position, 1f);

        //Vector3 targetDir = _player.position - transform.position;
        //float angle = Vector3.Angle(targetDir, transform.forward);

        //endPos = _player.position + Vector3.right * _castDist;

        
        _canShot = false;
        yield return new WaitForSeconds(_timeBTWShoots);
        GameObject newBullet = Instantiate(_bullet, _originalPoint.position, Quaternion.identity); 
        _effect.Play();
        

               
        
        //transform.position = Vector2.MoveTowards(transform.position, endPos, _shootSpeed * Time.deltaTime);
        //newBullet.GetComponent<Rigidbody2D>().velocity = endPos;

        // Instantiate(_bullet, _shootPos.position, Quaternion.identity);


        _canShot = true;
    }

     private IEnumerator SecondShoot()
     {
        yield return new WaitForSeconds(_timeBTWShoots);
        GameObject newBullett = Instantiate(_bullet, _firepointSecond.position, Quaternion.identity);     
        attackPoint = pointForBulletTwo;
     }

    private void SecondState()
    {
        for (int i = 0; i < _groundBoss.Length; i++)
        {
            _groundBoss[i].SetActive(false);
        }
    }

    private void ThirdState()
    {
        for (int i = 0; i < _sliderJooint.Length; i++)
        {
            _sliderJooint[i].enabled = true;
        }

        for (int i = 0; i < _sliderUp.Length; i++)
        {
            _sliderUp[i].enabled = true;
        }
    }
}
