using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageForHero : MonoBehaviour
{
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private Slider sliderLives;
    [SerializeField] private PlayerMovement PlayerMovement;
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyController>())
        {
            PlayerMovement.OnAnimator("IsDamage", true);
            playerSettings.Hp -= 10;
        }
        else
        {
            PlayerMovement.OnAnimator("IsDamage", false);
        }
    }

    private void Update()
    {
        sliderLives.value = playerSettings.Hp;
    }
}
