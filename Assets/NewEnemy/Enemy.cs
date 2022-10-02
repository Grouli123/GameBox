using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
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
    }

    private void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.gameObject.CompareTag("LimitedEnemy"))
        {
            currentState = idle_state;
        }

        if(collider.gameObject.CompareTag("DamageBullet"))
        {
            lives -= 1;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DamageBullet"))
        {
            lives -= 1;
        }
    }
}

