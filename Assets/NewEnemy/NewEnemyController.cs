using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyController : MonoBehaviour
{
    [SerializeField] private float speed, timeToRevert;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer sp;
    [SerializeField] private int lives;
    private Rigidbody2D rb;
    private const float idle_state = 0;
    private const float walk_state = 1;
    private const float revert_state = 2;

    private float currentState, currentTimeToRevert;

    private bool _canShot;
    [SerializeField] private float laserLength = 1;
    [SerializeField] private Transform _shootPos;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float timeBTWShoots;

    public void Start()
    {
        currentState = walk_state;
        currentTimeToRevert = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if(currentTimeToRevert >= timeToRevert)
        {
            currentTimeToRevert = 0;
            currentState = revert_state;
        }
        switch (currentState)
        {
            case idle_state:
                currentTimeToRevert += Time.deltaTime;
                break;
                case walk_state:
                rb.velocity = Vector2.right * speed;
                break;
                case revert_state:
                sp.flipX = !sp.flipX;
                speed *= -1;
                currentState = walk_state;
                break;
        }

        if(lives <= 0)
        {
            Destroy(gameObject);
        }

        anim.SetFloat("Velocity", rb.velocity.magnitude);

        CanSeePlayer();
    }

    private void CanSeePlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(_shootPos.position, Vector2.right, laserLength);

        if (hit.collider != null)
        {
            if(hit.collider.CompareTag("Player"))
            {
                StartCoroutine(Shoot());
            }

        }
        else
        {
        }
        Debug.DrawRay(_shootPos.position, Vector2.right * laserLength, Color.red);

    }

    private void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.gameObject.CompareTag("LimitedEnemy"))
        {
            currentState = idle_state;
        }

        if(collider.gameObject.CompareTag("DamageEnemy"))
        {
            lives -= 1;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DamageEnemy"))
        {
            lives -= 1;
        }
    }

    private IEnumerator Shoot()
    {
        _canShot = false;
        yield return new WaitForSeconds(timeBTWShoots);
        GameObject newBullet = Instantiate(_bullet, _shootPos.position, Quaternion.identity);
        //shootSound.Play();
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(1 * 30 * Time.fixedDeltaTime, 0f);
        _canShot = true;
    }
}
