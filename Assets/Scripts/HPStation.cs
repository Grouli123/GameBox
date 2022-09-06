using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPStation : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private TextMoveHelp textMoveHelp;
    [SerializeField] private BafHero bafHero;

    [Header("Other")]
    [SerializeField] private AudioClip[] audioClip;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Light light;
    [SerializeField] private Collider2D collider;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            textMoveHelp.Texting("ֽאזלטעו ֵ");
            textMoveHelp.FulText(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") & Input.GetKey(KeyCode.E))
        {
            int clipIndex = Random.Range(0, audioClip.Length - 1);
            audioSource.clip = audioClip[clipIndex];
            audioSource.Play();

            if (bafHero.onDobleLives == false)
            {
                playerSettings.Hp = 10;
            }
            else
            {
                playerSettings.Hp = 15;
            }
            Destroy(collider);
            Destroy(light, 20);
        }
    }
}
