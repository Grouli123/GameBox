using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageForHero : MonoBehaviour
{
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private PlayerMovement PlayerMovement;

    [Header("ImagesHP")]
    [SerializeField] private Image hpFull;
    [SerializeField] private Image hpFullDouble;
    [SerializeField] private Image hpNulDouble;

    public Animator anim;

    [SerializeField] private GameObject _baseStickHp;
    [SerializeField] private GameObject _doubleStickHp;

    [SerializeField] private bool _damageFromEnemiesCollision;
    [SerializeField] private AudioSource damageSound;

    private bool doubleHp = false;

    private void Start() 
    {
        _baseStickHp.SetActive(true);
        _doubleStickHp.SetActive(false);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<ShowCar>())
        {
            anim.SetBool("IsDamage", true);
        }
        else
        {
            anim.SetBool("IsDamage", false);
        }

        if (_damageFromEnemiesCollision == true)
        {
            if (collision.gameObject.GetComponent<EnemyController>())
            {
                anim.SetTrigger("IsHit");
                playerSettings.Hp -= 1;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyDamage>() & doubleHp == false)
        {
            damageSound.Play();
            playerSettings.Hp -= 1f;
            anim.SetTrigger("IsHit");
        }
        else if(collision.gameObject.GetComponent<EnemyDamage>() & doubleHp == true)
        {
            damageSound.Play();
            anim.SetTrigger("IsHit");
            playerSettings.Hp -= 1;
            playerSettings.LivesDouble -= 1;
        }
    }

    private void Update()
    {
        Debug.Log("Double hp^ " + doubleHp);
        HealthFill();
        DoubleHp();
    }

    private void HealthFill()
    {
        if(doubleHp == false)
        {
            hpFull.fillAmount = playerSettings.Hp / 10;
            hpFullDouble.gameObject.SetActive(false);
            hpNulDouble.gameObject.SetActive(false);
        }
        else
        {
            hpFullDouble.fillAmount = playerSettings.LivesDouble / 10;
            hpFull.fillAmount = playerSettings.Hp / 10;
            hpFullDouble.gameObject.SetActive(true);
            hpNulDouble.gameObject.SetActive(true);
        }
    }

    private void DoubleHp()
    {
        if(playerSettings.OnDoubleLives == true)
        {
            doubleHp = true;            
            _doubleStickHp.SetActive(true);
        }
        else
        {
            doubleHp = false;
            _baseStickHp.SetActive(true);

        }
    }
}
