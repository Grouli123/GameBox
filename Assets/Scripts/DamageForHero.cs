using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageForHero : MonoBehaviour
{
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private Slider sliderLives;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyController>())
        {
            playerSettings.Hp -= 10;
        }
    }

    private void Update()
    {
        sliderLives.value = playerSettings.Hp;
    }
}
