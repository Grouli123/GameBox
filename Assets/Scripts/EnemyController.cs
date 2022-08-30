using UnityEngine;
using System.Collections;
public class EnemyController : MonoBehaviour
{
    public float walkSpeed, range, timeBTWShoots, shootSpeed;
    private float distToPlayer;
    private bool mustTurn, canShot;

    [HideInInspector]
    public bool mustPatrol;

    public Rigidbody2D rb;

    public Transform groundCheckPosition;

    public LayerMask groundLayer;
    public Collider2D bodyCollider;

    public Transform player, shootPos;
    public GameObject bullet;

    private void Start()
    {
        mustPatrol = true;
        canShot = true;
    }

    private void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }

        distToPlayer = Vector2.Distance(transform.position, player.position);

        if(distToPlayer <= range)
        {
            if (player.position.x > transform.position.x && transform.localScale.x < 0
            || player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                Flip();
            }

            mustPatrol = false;
            rb.velocity = Vector2.zero;
            if(canShot)
            StartCoroutine(Shoot());
        }
        else
        {
            mustPatrol = true;
        }
    }

    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPosition.position, 0.1f, groundLayer);
        }
    }

    private void Patrol()
    {
        if (mustTurn || bodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    private void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }

    IEnumerator Shoot()
    {
        canShot = false;
        yield return new WaitForSeconds(timeBTWShoots);
        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);

        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * walkSpeed * Time.fixedDeltaTime, 0f);

        canShot = true;

    }
}
