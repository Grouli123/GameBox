using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageForEnemy : MonoBehaviour
{
    [SerializeField] private float lives;
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private ButtonForGame buttonForGame;

    private bool doubleDamage;

    private void Start()
    {
        lives = 10f;
        doubleDamage = false;
    }

    private void Update()
    {
        if(lives <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DamageEnemy") & doubleDamage == true)
        {
            this.lives -= 10f;
            Debug.Log("Double");
        }
        else if(collision.gameObject.CompareTag("DamageEnemy") & doubleDamage == false)
        {
            this.lives -= 5f;
            Debug.Log("NonDouble");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(buttonForGame.Freeze == true)
        {
            enemyController.enabled = false;
        }
        else
        {
            enemyController.enabled = true;
        }

        if(buttonForGame.Lives < 0)
        {
            enemyController.enabled = false;
        }
    }

    public bool DoubleDamage
    {
        get { return doubleDamage; }
        set { doubleDamage = value; }
    }
}
