using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private float _moveSpeed = 7f;
    private Rigidbody2D _rb;
    [SerializeField] private PlayerMovement _target;
    private Vector2 _moveDirection;

    private void Start() 
    {
        _rb = GetComponent<Rigidbody2D>();
        _target = GameObject.FindObjectOfType<PlayerMovement>();
        _moveDirection = (_target.transform.position - transform.position).normalized * _moveSpeed;
        _rb.velocity = new Vector2(_moveDirection.x, _moveDirection.y);
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject, 0);
        }
   }
}
