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
    [SerializeField] private new Light light;
    [SerializeField] private new Collider2D collider;
    [SerializeField] private Material emission;
    [SerializeField] private float livesStation;

    private float _hpPlayer;
    private Renderer ren;

    private void Start()
    {
        livesStation = 20;
        ren = GetComponent<Renderer>();
    }

    private void Update()
    {
        Sound();
        HpPlayer();
    }

    private void HpPlayer()
    {
        if(bafHero.onDobleLives == false)
        {
            _hpPlayer = 10 - playerSettings.Hp;
        }
        else
        {
           _hpPlayer = 15 - playerSettings.Hp;
        }
    }

    private void Sound()
    {
        if (audioSource.isPlaying)
        {
            int clipIndex = Random.Range(0, audioClip.Length - 1);
            audioSource.clip = audioClip[clipIndex];
            audioSource.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            textMoveHelp.Texting("E - пополнить здоровье");
            textMoveHelp.FulText(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") & Input.GetKey(KeyCode.E))
        {
            if (bafHero.onDobleLives == false & livesStation >= _hpPlayer)
            {
                playerSettings.Hp += _hpPlayer;
                livesStation -= _hpPlayer;
            }
            else if(bafHero.onDobleLives == true & livesStation >= _hpPlayer)
            {
                playerSettings.Hp += _hpPlayer;
                livesStation -= _hpPlayer;
            }
            else if(bafHero.onDobleLives == false & livesStation < _hpPlayer & livesStation > 0)
            {
                playerSettings.Hp += livesStation;
                livesStation -= livesStation;
            }
            else if(bafHero.onDobleLives == true & livesStation < _hpPlayer & livesStation > 0)
            {
                playerSettings.Hp += livesStation;
                livesStation -= livesStation;
            }
            else if(livesStation <= 0)
            {
                Destroy(collider);
                ren.material.DisableKeyword("_EMISSION");
                audioSource.Stop();
            }
        }
    }
}
