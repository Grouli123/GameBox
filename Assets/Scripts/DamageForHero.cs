using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageForHero : MonoBehaviour
{
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private PlayerMovement PlayerMovement;

    [Header("ImagesHP")]
    // [SerializeField] private Sprite NotHP;
    //  [SerializeField] private Image[] hp;
    //  [SerializeField] private Sprite[] colorHP;
    [SerializeField] private Image hpFull;
   // [SerializeField] private Image hpNull;
   // private float score;



    
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
        // OnHealth();
        Health();
    }

    private void Health()
    {
        hpFull.fillAmount = playerSettings.Hp / 10;
    }

   /* public void OnHealth()
    {
        switch (playerSettings.Hp)
        {
            case 0:
                hp[9].sprite = NotHP;
                hp[8].sprite = NotHP;
                hp[7].sprite = NotHP;
                hp[6].sprite = NotHP;
                hp[5].sprite = NotHP;
                hp[4].sprite = NotHP;
                hp[3].sprite = NotHP;
                hp[2].sprite = NotHP;
                hp[1].sprite = NotHP;
                hp[0].sprite = NotHP;
                break;
            case 1:
                hp[9].sprite = NotHP;
                hp[8].sprite = NotHP;
                hp[7].sprite = NotHP;
                hp[6].sprite = NotHP;
                hp[5].sprite = NotHP;
                hp[4].sprite = NotHP;
                hp[3].sprite = NotHP;
                hp[2].sprite = NotHP;
                hp[1].sprite = NotHP;
                hp[0].sprite = colorHP[0];
                break;
            case 2:
                hp[9].sprite = NotHP;
                hp[8].sprite = NotHP;
                hp[7].sprite = NotHP;
                hp[6].sprite = NotHP;
                hp[5].sprite = NotHP;
                hp[4].sprite = NotHP;
                hp[3].sprite = NotHP;
                hp[2].sprite = NotHP;
                hp[1].sprite = colorHP[1];
                hp[0].sprite = colorHP[0];
                break;
            case 3:
                hp[9].sprite = NotHP;
                hp[8].sprite = NotHP;
                hp[7].sprite = NotHP;
                hp[6].sprite = NotHP;
                hp[5].sprite = NotHP;
                hp[4].sprite = NotHP;
                hp[3].sprite = NotHP;
                hp[2].sprite = colorHP[2];
                hp[1].sprite = colorHP[1];
                hp[0].sprite = colorHP[0];
                break;
            case 4:
                hp[9].sprite = NotHP;
                hp[8].sprite = NotHP;
                hp[7].sprite = NotHP;
                hp[6].sprite = NotHP;
                hp[5].sprite = NotHP;
                hp[4].sprite = NotHP;
                hp[3].sprite = colorHP[3];
                hp[2].sprite = colorHP[2];
                hp[1].sprite = colorHP[1];
                hp[0].sprite = colorHP[0];
                break;
            case 5:
                hp[9].sprite = NotHP;
                hp[8].sprite = NotHP;
                hp[7].sprite = NotHP;
                hp[6].sprite = NotHP;
                hp[5].sprite = NotHP;
                hp[4].sprite = colorHP[4];
                hp[3].sprite = colorHP[3];
                hp[2].sprite = colorHP[2];
                hp[1].sprite = colorHP[1];
                hp[0].sprite = colorHP[0];
                break;
            case 6:
                hp[9].sprite = NotHP;
                hp[8].sprite = NotHP;
                hp[7].sprite = NotHP;
                hp[6].sprite = NotHP;
                hp[5].sprite = colorHP[5];
                hp[4].sprite = colorHP[4];
                hp[3].sprite = colorHP[3];
                hp[2].sprite = colorHP[2];
                hp[1].sprite = colorHP[1];
                hp[0].sprite = colorHP[0];
                break;
            case 7:
                hp[9].sprite = NotHP;
                hp[8].sprite = NotHP;
                hp[7].sprite = NotHP;
                hp[6].sprite = colorHP[6];
                hp[5].sprite = colorHP[5];
                hp[4].sprite = colorHP[4];
                hp[3].sprite = colorHP[3];
                hp[2].sprite = colorHP[2];
                hp[1].sprite = colorHP[1];
                hp[0].sprite = colorHP[0];
                break;
            case 8:
                hp[9].sprite = NotHP;
                hp[8].sprite = NotHP;
                hp[7].sprite = colorHP[7];
                hp[6].sprite = colorHP[6];
                hp[5].sprite = colorHP[5];
                hp[4].sprite = colorHP[4];
                hp[3].sprite = colorHP[3];
                hp[2].sprite = colorHP[2];
                hp[1].sprite = colorHP[1];
                hp[0].sprite = colorHP[0];
                break;
            case 9:
                hp[9].sprite = NotHP;
                hp[8].sprite = colorHP[8];
                hp[7].sprite = colorHP[7];
                hp[6].sprite = colorHP[6];
                hp[5].sprite = colorHP[5];
                hp[4].sprite = colorHP[4];
                hp[3].sprite = colorHP[3];
                hp[2].sprite = colorHP[2];
                hp[1].sprite = colorHP[1];
                hp[0].sprite = colorHP[0];
                break;
            case 10:
                hp[9].sprite = colorHP[9];
                hp[8].sprite = colorHP[8];
                hp[7].sprite = colorHP[7];
                hp[6].sprite = colorHP[6];
                hp[5].sprite = colorHP[5];
                hp[4].sprite = colorHP[4];
                hp[3].sprite = colorHP[3];
                hp[2].sprite = colorHP[2];
                hp[1].sprite = colorHP[1];
                hp[0].sprite = colorHP[0];
                break;
        }
    }*/
}
