using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeToRevert;
    // [SerializeField] private Animator _anim;    
    [SerializeField] private SpriteRenderer _sp;

    [SerializeField] private Transform _target;

    private Rigidbody2D _rb;

    private const float _idleState = 0;
    private const float _walkState = 1;
    private const float _revertState = 2;

    private float _currentState;
    private float _currentTimeToRevert;

    [SerializeField] private bool _isHeroFound; // если поставить true, то он будет преследовать игрока,
                                                // если поставить false, то он будет патрулировать от одного тригера
                                                // к другому и при столкновении с одним из тригеров переключается на false,
                                                // то есть на патрулирование.

    private void Start()
    {
        _currentState = _walkState;
        _currentTimeToRevert = 0;
        _rb = GetComponent<Rigidbody2D>();

        _target.GetComponent<Transform>();
        _isHeroFound = true;
    }

    private void Update()
    {
        if (_isHeroFound == false){
            if(_currentTimeToRevert >= _timeToRevert)
            {
                _currentTimeToRevert = 0;
                _currentState = _revertState;
            }

            switch(_currentState)
            {
                case _idleState:
                    _currentTimeToRevert += Time.deltaTime;
                    break;
                case _walkState:
                    _rb.velocity = Vector2.left * _speed;
                    break;
                case _revertState:
                    _sp.flipX = !_sp.flipX;
                    _speed *= -1;
                    _currentState = _walkState;
                    break;
            }

            // _anim.SetFloat("Velocity",_rb.velocity.magnitude);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);    
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        _currentState = _idleState;    
        _isHeroFound = false;
    }
}
