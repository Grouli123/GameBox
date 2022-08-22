using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeToRevert;
    // [SerializeField] private Animator _anim;    
    [SerializeField] private SpriteRenderer _sp;

    private Rigidbody2D _rb;

    private const float _idleState = 0;
    private const float _walkState = 1;
    private const float _revertState = 2;

    private float _currentState;
    private float _currentTimeToRevert;

    private void Start()
    {
        _currentState = _walkState;
        _currentTimeToRevert = 0;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
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

    private void OnTriggerEnter2D(Collider2D other) 
    {
        _currentState = _idleState;    
    }
}
