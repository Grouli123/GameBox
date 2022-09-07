using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private float _moveSpeed = 7f;
    private Rigidbody2D _rb;
    [SerializeField] private PlayerMovement _target;
    
    [SerializeField] private LayerMask _groundLayer;
    private Vector2 _moveDirection;
    [SerializeField] private string _groundLayerName;

    private void Start() 
    {
        _rb = GetComponent<Rigidbody2D>();
        _target = GameObject.FindObjectOfType<PlayerMovement>();
        _moveDirection = (_target.transform.position - transform.position).normalized * _moveSpeed;
        _rb.velocity = new Vector2(_moveDirection.x, 0);
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject, 0);
        }
   }
}
