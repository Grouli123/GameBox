using Scriptable;
using UnityEngine;

public class DamageForBoss : MonoBehaviour
{
    [SerializeField] private GameObject _finishCutscene;

    public float lives;
    [SerializeField] private DamageDealler damageDealler;

    [SerializeField] private IntegerVariable _allOfScore;
    [SerializeField] private IntegerVariable _enemyCounter;
    [SerializeField] private int _scoreForEnemyDeath;

    private void Start()
    {
        // _finishCutscene.SetActive(false);
        lives = 10f;
        _enemyCounter.SetValue(0);
    }

    private void Update()
    {
        if(lives <= 0)
        {
            Destroy(gameObject);
            _enemyCounter.ApplyChange(_scoreForEnemyDeath);
            _allOfScore.ApplyChange(_scoreForEnemyDeath);
            _finishCutscene.SetActive(true);
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
}