using UnityEngine;

public class BossBullet : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private Rigidbody2D _rb;
    [SerializeField] private PlayerMovement _target;

    // [SerializeField] private GameObject _firePoint;

    private Transform _player;
    private Vector2 _moveTargetDirection;

    
    [SerializeField] private Rigidbody2D _playerRb;
    // [SerializeField] private PlayerSettings _playerSettings;

    private void Start() 
    {
        // _rb = GetComponent<Rigidbody2D>();
       _target = GameObject.FindObjectOfType<PlayerMovement>();
        //_firePoint = GameObject.FindGameObjectWithTag("FirePoint");
        _playerRb = _target.rb;


        // _moveTargetDirection = (_target.transform.position - transform.position);
        // _rb.velocity = new Vector2(_moveTargetDirection.x, _moveTargetDirection.y);

        // Destroy(gameObject, 1f);




        _player = GameObject.FindGameObjectWithTag("Player").transform;

        _moveTargetDirection = new Vector2(_player.position.x, _player.position.y);

    }

    private void Update() 
    {
        transform.position = Vector2.MoveTowards(transform.position, _moveTargetDirection, _moveSpeed * Time.deltaTime);

        if (transform.position.x == _moveTargetDirection.x && transform.position.y == _moveTargetDirection.y)
        {
            DestroyBossBullet();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            //выместо вектор ап написать направление куда полетит главный герой
            _playerRb.AddForce(Vector2.up  * 3, ForceMode2D.Impulse);
            DestroyBossBullet();
        }
   }

   private void DestroyBossBullet()
   {
        Destroy(gameObject);
   }
}
