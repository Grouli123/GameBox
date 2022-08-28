using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageForEnemy : MonoBehaviour
{
    [SerializeField] private float lives;
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private ButtonForGame buttonForGame;

    private void Update()
    {
        if(lives < 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DamageEnemy"))
        {
            lives -= 10;
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
    }
}
