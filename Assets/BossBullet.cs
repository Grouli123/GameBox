using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private float _moveSpeed = 7f;
    private Rigidbody2D _rb;
    [SerializeField] private PlayerMovement _target;

    [SerializeField] private GameObject _firePoint;

    private Transform _player;
    private Vector2 _moveDirection;

    
    [SerializeField] private Rigidbody2D _playerRb;
    [SerializeField] private PlayerSettings _playerSettings;

    private void Start() 
    {
        _rb = GetComponent<Rigidbody2D>();
        _target = GameObject.FindObjectOfType<PlayerMovement>();
        _firePoint = GameObject.FindGameObjectWithTag("FirePoint");
        _playerRb = _target.rb;


        // _moveDirection = (_target.transform.position - transform.position);
        // _rb.velocity = new Vector2(_moveDirection.x, _moveDirection.y);

        Destroy(gameObject, 3f);
        _player = GameObject.FindGameObjectWithTag("Player").transform;

        _moveDirection = new Vector2(_player.position.x, _player.position.y);

    }

    private void Update() 
    {
        transform.position = Vector2.MoveTowards(_firePoint.transform.position, _moveDirection, _moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            Debug.Log("получен");
            //_playerRb.AddForce(  * 2, ForceMode2D.Impulse);
            Destroy(gameObject, 0);
        }
        else
        {
            Destroy(gameObject);
        }
   }
}
