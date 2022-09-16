using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private float _moveSpeed = 7f;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private PlayerMovement _target;
    private EnemyController _enemyController;
    
    private Vector2 _moveDirection;
    private void Start() 
    {
        _rb = GetComponent<Rigidbody2D>();
        _target = GameObject.FindObjectOfType<PlayerMovement>();
        _enemyController = GameObject.FindObjectOfType<EnemyController>();
        _moveDirection = (_target.transform.position - transform.position).normalized * _moveSpeed;
        _rb.velocity = new Vector2(_moveDirection.x, 0);
        
        Destroy(gameObject, 3f);

        
        
        // if (_moveSpeed <= 5f)
        // {
        //     Destroy(gameObject);
        // }
    }

    private void Update() 
    {
        if(_enemyController.isFlipBullet == true)
        {
            _moveSpeed *= -1f;
        }
        else
        {
            _moveSpeed *= -1f;
        }    
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.layer == 3)
        {
            Destroy(gameObject);
        }

    }
}
