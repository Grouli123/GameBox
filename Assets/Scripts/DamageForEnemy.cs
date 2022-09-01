using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageForEnemy : MonoBehaviour
{
    [SerializeField] private float lives;
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private ButtonForGame buttonForGame;
    [SerializeField] private DamageDealler damageDealler;

    private void Start()
    {
        lives = 10f;
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
        if (collision.gameObject.CompareTag("DamageEnemy") & damageDealler.DoubleDamage == true)
        {
            lives -= damageDealler.Damage;
            Debug.Log("Double");
        }
        else if(collision.gameObject.CompareTag("DamageEnemy") & damageDealler.DoubleDamage == false)
        {
            lives -= damageDealler.Damage * 2;
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
}
