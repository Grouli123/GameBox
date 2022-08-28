using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDeath : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private PlayerSettings playerSettings;

    [Header("Objects")]
    [SerializeField] private GameObject deathPanel;

    private void Update()
    {
        Death();
    }
    public void Death()
    {
        if(playerSettings.Cassete <= 0 & playerSettings.Hp < 0)
        {
            Time.timeScale = 0;
            deathPanel.SetActive(true);
        }
    }
}
