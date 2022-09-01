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

    private bool doubleHp = false;

    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyController>())
        {
            PlayerMovement.OnAnimator("IsDamage", true);
            playerSettings.Hp -= 1;
        }
        else
        {
            PlayerMovement.OnAnimator("IsDamage", false);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyDamage>())
        {
            playerSettings.Hp -= 1f;
            PlayerMovement.OnAnimator("IsDamage", true);
        }
        else
        {
            PlayerMovement.OnAnimator("IsDamage", false);
        }
    }

    private void Update()
    {
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
            if(playerSettings.Hp > 10)
            {
                hpFullDouble.fillAmount = (playerSettings.Hp - 5) / 10;
            }
            else if(playerSettings.Hp <= 10)
            {
                hpFull.fillAmount = playerSettings.Hp / 10;
            }
            hpFullDouble.gameObject.SetActive(true);
            hpNulDouble.gameObject.SetActive(true);
        }
    }

    private void DoubleHp()
    {
        if(playerSettings.OnDoubleLives == true)
        {
            doubleHp = true;
        }
        else
        {
            doubleHp = false;
        }
    }
}
