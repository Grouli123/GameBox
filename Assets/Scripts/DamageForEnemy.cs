using Scriptable;
using System.Collections;
using UnityEngine;

public class DamageForEnemy : MonoBehaviour
{
    public float lives;
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private ButtonForGame buttonForGame;
    [SerializeField] private DamageDealler damageDealler;

    [SerializeField] private IntegerVariable _allOfScore;
    [SerializeField] private IntegerVariable _enemyCounter;
    [SerializeField] private int _scoreForEnemyDeath;

    [SerializeField] private Animator _anim;

    private void Start()
    {
        _enemyCounter.SetValue(0);
    }

    private void Update()
    {

        Freeze();
        if (lives <= 0)
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
            _anim.SetBool("Damage", true);
            lives -= damageDealler.Damage * 2;
        }
        else if (collision.gameObject.CompareTag("DamageEnemy") & damageDealler.DoubleDamage == false)
        {
            _anim.SetBool("Damage", true);
            lives -= damageDealler.Damage;
        }
        else
        {
            _anim.SetBool("Damage", false);
        }
    }

    private void Freeze()
    {
        if (buttonForGame.Freeze == true)
        {
            _anim.SetBool("Idle", true);
            StartCoroutine(Speed());
        }
        else
        {
            _anim.SetBool("Idle", false);
            gameObject.GetComponent<EnemyController>().enabled = true;
        }
    }

    private IEnumerator Speed()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<EnemyController>().WalkSpeed = 0;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<EnemyController>().enabled = false;
        yield return new WaitForSeconds(3);
        if (gameObject.GetComponent<EnemyController>().Range > 0)
        {
            gameObject.GetComponent<EnemyController>().WalkSpeed = 30;
        }
        else
        {
            gameObject.GetComponent<EnemyController>().WalkSpeed = -30;
        }
    } 
}

