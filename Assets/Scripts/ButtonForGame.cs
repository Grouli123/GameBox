using System.Collections;
using UnityEngine;

public class ButtonForGame : MonoBehaviour
{
    [Header("scripts")]
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private PlayerInput playerInput;
    [Header("Objects")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject helpPanel;

    [Header("Sound")]
    [SerializeField] private AudioSource _hairGelSound;

    private bool _pauseActive;
    private float _timeFreeze;
    private float _timeAnim;
    private bool _freeze;

    private float _stopAttack;

    private void Awake() 
    {
       _stopAttack = enemyController.timeBTWShoots;
    }

    private void Start()
    {        
        _pauseActive = false;
        _freeze = false;
    }

    private void Update()
    {
        _timeFreeze -= Time.deltaTime;
        _timeAnim -= Time.deltaTime;
        OnClickPause();
        OnClickFreeze();
    }
    public void OnClickPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_pauseActive == false)
            {
                playerInput.enabled = false;
                enemyController.enabled = false;
                helpPanel.SetActive(false);
                _pauseActive = true;
                pausePanel.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                enemyController.enabled=true;
                ContinueGame();
            }
        }
    }

    public void ContinueGame()
    {
        enemyController.enabled = false;
        playerInput.enabled = true;
        helpPanel.SetActive(true);
        _pauseActive = false;
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void OnClickFreeze()
    {
        if(Input.GetKeyDown(KeyCode.Q) & playerSettings.HairGel >= 3 )
        {
            _hairGelSound.Play();
            playerMovement.OnAnimator("Stun", true);
            _timeAnim = 1;
            _timeFreeze = 5;
            _stopAttack = 5;
            _freeze = true;
            playerSettings.HairGel = 0;
        }

        if(_timeAnim < 0)
        {
            playerMovement.OnAnimator("Stun", false);
        }

        if (_timeFreeze < 0)
        {
            _freeze = false;            
            _stopAttack = 0.5f;
        }
    }

    public bool Freeze
    {
        get { return _freeze; }
        set { _freeze = value; }
    }

    public float Lives
    {
        get { return playerSettings.Hp; }
        set { playerSettings.Hp = value; }
    }
}
