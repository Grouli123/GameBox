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

    [SerializeField] TimerToEnd _timeToEnd;

    private void Start()
    {
        _timeToEnd = GetComponent<TimerToEnd>();
        // _finishCutscene.SetActive(false);
        lives = 50f;
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

        if (lives <= 0 && _timeToEnd.endTimeToUpScore > 0)
        {
            _scoreForEnemyDeath += 10000;
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