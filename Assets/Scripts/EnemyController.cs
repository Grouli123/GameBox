using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float lives;
    [SerializeField] private GameObject _bullet;  
    [SerializeField] private Transform _firePoint;
    [SerializeField] private Transform _flipEnemy;
   private float _fireRate;
   private float _nextFire;

    //[SerializeField] private Transform _firePoint;
    [SerializeField] private Transform _pointOfRevert;    
    [SerializeField] private Transform _player;

    [SerializeField] private float _stoppingDistance;
    [SerializeField] private float _speed;

    [SerializeField] private int _positionOfPatrol;

    private bool _isMovingRight = true;
    private bool _isIdle = false;
    private bool _isAngry = false;
    private bool _isBackToAPoint = false;

    private Vector2 _enemyTarget;

    [SerializeField] private float _currentSpeed;

    private void Start() 
    {
        _fireRate = 1f;
        _nextFire = Time.time;


        _player.GetComponent<Transform>();
        //_bullet.GetComponent<GameObject>();

        _speed = _currentSpeed;
        
        //_enemyTarget = new Vector2(_bullet.transform.position.x, _bullet.transform.position.y);
    }

    private void Update() 
    {
        if (Vector2.Distance(transform.position, _pointOfRevert.position) < _positionOfPatrol && _isAngry == false)
        {
            _isIdle = true;
        }    

        if (Vector2.Distance(transform.position, _player.position) < _stoppingDistance)
        {
            _isAngry = true;
            _isIdle = false;
            _isBackToAPoint = false;
        }

        if (Vector2.Distance(transform.position, _player.position) > _stoppingDistance)
        {
            _isBackToAPoint = true;
            _isAngry = false;
        }

        if (_isIdle == true)
        {
            Idle();
        }
        else if (_isAngry == true)
        {
            Angry();
        }
        else if (_isBackToAPoint)
        {
            BackToAPoint();
        }

        if(lives < 0)
        {
            Destroy(gameObject);
        }
    }

    private void Idle()
    {
        if (transform.position.x > _pointOfRevert.position.x + _positionOfPatrol)
        {
            
            _isMovingRight = false;
            
            _flipEnemy.transform.Rotate(0f, 180f, 0f);
            Debug.Log("1");
        }
        else if (transform.position.x < _pointOfRevert.position.x - _positionOfPatrol)
        {
            _isMovingRight = true;
            
            _flipEnemy.transform.Rotate(0f, 180f, 0f);
            Debug.Log("2");
        }

        if (_isMovingRight)
        {
            transform.position = new Vector2(transform.position.x + _speed * Time.deltaTime, transform.position.y);
            
        }
        else
        {
            transform.position = new Vector2(transform.position.x - _speed * Time.deltaTime, transform.position.y);


        }
    }

    private void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);
        //transform.Rotate(0f, 180f, 0f);

        _speed = _currentSpeed * 1.2f;
        CheakIfTimeToFire();
        
       

       
       
        //GameObject _currentBullet = Instantiate(_bullet, _firePoint.position, _firePoint.rotation);

    }

    private void BackToAPoint()
    {        
        transform.position = Vector2.MoveTowards(transform.position, _pointOfRevert.position, _speed * Time.deltaTime);
        _speed = _currentSpeed;
    }

    private void CheakIfTimeToFire()
    {
        if (Time.time > _nextFire)
        {
            Instantiate(_bullet, _firePoint.transform.position, Quaternion.identity);
            _nextFire = Time.time + _fireRate;
        }
    }

    public float Lives
    {
        get { return lives; }
        set { lives = value; }
    }


}
