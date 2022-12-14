using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletTwo : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private Rigidbody2D _rb;
    [SerializeField] private PlayerMovement _target;

    // [SerializeField] private GameObject _firePoint;

    private Transform _player;
    private Vector2 _moveTargetDirection;

    private Vector2 _movePlayerFromBullet;

    [SerializeField] private float _forseImpulse;

    private BossControllerTwo _bossControllerTwo;
    
    [SerializeField] private Rigidbody2D _playerRb;
    [SerializeField] private PlayerSettings _playerSettings;

    

    private void Start() 
    {
        // _rb = GetComponent<Rigidbody2D>();
       _target = GameObject.FindObjectOfType<PlayerMovement>();
        _bossControllerTwo = GameObject.FindObjectOfType<BossControllerTwo>();
       _playerRb = GetComponent<Rigidbody2D>();
        _playerSettings = GameObject.FindObjectOfType<PlayerSettings>();

        //_firePoint = GameObject.FindGameObjectWithTag("FirePoint");
        _playerRb = _target.rb;


        _movePlayerFromBullet = (_playerRb.transform.position - transform.position);
        // _rb.velocity = new Vector2(_test.x, _test.y);

        // Destroy(gameObject, 1f);




        _player = GameObject.FindGameObjectWithTag("Player").transform;

        _moveTargetDirection = new Vector2(_bossControllerTwo.attackPoint.position.x, _bossControllerTwo.attackPoint.position.y);

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
            _playerRb.AddForce(_movePlayerFromBullet  * _forseImpulse, ForceMode2D.Impulse);
            _playerSettings.Hp -= 1 ;
            DestroyBossBullet();
        }
   }

   private void DestroyBossBullet()
   {
        Destroy(gameObject);
   }
}
