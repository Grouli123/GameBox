using UnityEngine;

public class CarDamage : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private PlayerSettings _playerSettings;
    [SerializeField] private DamageForHero _damageForHEro;
    
    private void Start() {
        _rb.GetComponent<Rigidbody>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _rb.AddForce(Vector2.up * 3, ForceMode2D.Impulse);
            _playerSettings.Hp -= 1;
            _damageForHEro.anim.SetTrigger("IsHit");
        }
    }
}
