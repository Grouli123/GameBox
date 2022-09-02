using Scriptable;
using UnityEngine;

public class DamageForEnemy : MonoBehaviour
{
    [SerializeField] private float lives;
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private ButtonForGame buttonForGame;
    [SerializeField] private DamageDealler damageDealler;

    [SerializeField] private IntegerVariable _allOfScore;
    [SerializeField] private IntegerVariable _enemyCounter;
    [SerializeField] private int _scoreForEnemyDeath;

    private void Start()
    {
        lives = 10f;
        _enemyCounter.SetValue(0);
    }

    private void Update()
    {

        Freeze();
        if(lives <= 0)
        {
            Destroy(gameObject);
            _enemyCounter.ApplyChange(_scoreForEnemyDeath);
            _allOfScore.ApplyChange(_scoreForEnemyDeath);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DamageEnemy") & damageDealler.DoubleDamage == true)
        {
            lives -= damageDealler.Damage * 2;
        }
        else if(collision.gameObject.CompareTag("DamageEnemy") & damageDealler.DoubleDamage == false)
        {
            lives -= damageDealler.Damage;
        }
    }

    private void Freeze()
    {
        if(buttonForGame.Freeze == true)
        {
            gameObject.GetComponent<EnemyController>().enabled = false;
            //enemyController.enabled = false;
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
