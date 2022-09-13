using Scriptable;
using System.Collections;
using UnityEngine;

public class DamageForEnemy : MonoBehaviour
{
    public float lives;
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private ButtonForGame buttonForGame;
    [SerializeField] private DamageDealler damageDealler;
    [SerializeField] private DialogPanel dialogPanel;

    [SerializeField] private IntegerVariable _allOfScore;
    [SerializeField] private IntegerVariable _enemyCounter;
    [SerializeField] private int _scoreForEnemyDeath;

    [SerializeField] private Animator _anim;

    [SerializeField] private AudioSource damageSound;

    private void Start()
    {
        _enemyCounter.SetValue(0);
    }

    private void Update()
    {
        Freeze();
        if (lives <= 0 && dialogPanel.Enemy == true)
        {
            Destroy(gameObject);
            _enemyCounter.ApplyChange(_scoreForEnemyDeath);
            _allOfScore.ApplyChange(_scoreForEnemyDeath);
            dialogPanel.OnActivePanelEnemy(true);
            Time.timeScale = 0;
        }
        else if(lives <= 0 && dialogPanel.Enemy == false)
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
            damageSound.Play();
            _anim.SetBool("Damage", true);
            lives -= damageDealler.Damage * 2;
           enemyController.WalkSpeed = 0;
           StartCoroutine(Hit());
        }
        else if (collision.gameObject.CompareTag("DamageEnemy") & damageDealler.DoubleDamage == false)
        {
            damageSound.Play();
            _anim.SetBool("Damage", true);
            lives -= damageDealler.Damage;
            enemyController.WalkSpeed = 0;
           StartCoroutine(Hit());
        }
        else
        {
            _anim.SetBool("Damage", false);

            // _animatorHit.SetTrigger("IsHit");
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

    private IEnumerator Hit()
    {
        yield return new WaitForSeconds(0.35f);
        // enemyController.WalkSpeed = 30;
        if (gameObject.GetComponent<EnemyController>().Range > 0)
        {
            _anim.SetBool("Damage", false);
            gameObject.GetComponent<EnemyController>().WalkSpeed = 30;
            
        }
        else
        {
            _anim.SetBool("Damage", false);
            gameObject.GetComponent<EnemyController>().WalkSpeed = -30;
        }
    }
}

