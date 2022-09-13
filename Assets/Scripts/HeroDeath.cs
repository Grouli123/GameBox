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

    [SerializeField] private GameObject _shootSound;

    [Header("Objects")]
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private GameObject deathPanelGoose;
    [SerializeField] private Image colorPanel;
    [SerializeField] private Text casseteText;
    [SerializeField] private Animator deathAnimImage;
    [SerializeField] private Sprite[] Click;
    [SerializeField] private Image clickImage;
    [SerializeField] private Button ClickedButton;

    private void Start() 
    {
        _shootSound.SetActive(true);
        Time.timeScale = 1;    
    }  
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
            if (playerSettings.Cassete <= 0)
            {                
               deathPanelGoose.SetActive(true);
            }
            else
            {
                deathPanel.SetActive(true);
            }
            
            playerMovement.Speed = 0f;
            AgainStartMenu.startMainMenu = true;
            _shootSound.SetActive(false);            
            Time.timeScale = 0;    
        }
        else
        {
            playerMovement.Speed = 0.5f;            
            Time.timeScale = 1;    
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
