using System.Collections;
using UnityEngine;

public class DamageDealler : MonoBehaviour
{
    [SerializeField] private float _damage;
    // public float timeBetweenShoots;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _fireSpeed;
    [SerializeField] private Rigidbody2D _rb;

    private bool doubleDamage = false;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            Destroy(gameObject);
        }
    }

    // private IEnumerator Cooldown()
    // {
    //     yield return new WaitForSeconds(timeBetweenShoots);
    //     _rb.velocity = transform.right * _fireSpeed;

    // }

    public bool DoubleDamage
    {
        get { return doubleDamage; }
        set { doubleDamage = value; }
    }

    public float Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
}
