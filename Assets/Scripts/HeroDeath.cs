using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroDeath : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private EnemyController enemyController;

    [Header("Objects")]
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private Image colorPanel;
    [SerializeField] private Text casseteText;
    [SerializeField] private Animator deathAnimImage;
    [SerializeField] private Sprite[] Click;
    [SerializeField] private Image clickImage;
    [SerializeField] private Button ClickedButton;

    private void Update()
    {
        casseteText.text = playerSettings.Cassete.ToString();
        Death();
        ClickOnContinue();
    }
    public void Death()
    {
        if(playerSettings.Hp <= 0 || playerMovement.FallDetector == true)
        {
            playerMovement.Speed = 0f;
            deathPanel.SetActive(true);
            AgainStartMenu.startMainMenu = true;
        }
        else
        {
            playerMovement.Speed = 0.5f;
        }
    }

    public void ClickOnContinue()
    {
        if(playerSettings.Cassete <= 0)
        {
            clickImage.sprite = Click[0];
            ClickedButton.interactable = false;
        }
        else
        {
            clickImage.sprite= Click[1];
            ClickedButton.interactable = true;
        }
    }

    public void PanelDeath(bool active)
    {
        deathPanel.SetActive(active);
    }

}
