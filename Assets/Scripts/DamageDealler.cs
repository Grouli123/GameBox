using UnityEngine;

public class DamageDealler : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _fireSpeed;
    [SerializeField] private Rigidbody2D _rb;

    private void Start() 
    {
        _rb.velocity = transform.right * _fireSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.isTrigger != true)
        {
            // if(collision.CompareTag("Damageable"))
            // {
            //    // collision.gameObject.GetComponent<Health>().TakeDamage(_damage);
            // }
            Destroy(_bullet, 1.5f);     
        }   
    }
}
