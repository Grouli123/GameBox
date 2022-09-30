using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private Text textTimeFreeze;

    [Header("Sound")]
    [SerializeField] private AudioSource _hairGelSound;

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
        Cursor.visible = false;     
        _freeze = false;
    }

    private void Update()
    {
        
        textTimeFreeze.text = Mathf.Round(_timeFreeze).ToString();
        _timeFreeze -= Time.deltaTime;
        _timeAnim -= Time.deltaTime;
        OnClickPause();
        OnClickFreeze();
    }
    public void OnClickPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) & pausePanel.activeSelf == false)
        {
            Cursor.visible = true;
            playerInput.enabled = false;
            enemyController.enabled = false;
            helpPanel.SetActive(false);
            pausePanel.SetActive(true);
            Time.timeScale = 0;
            enemyController.enabled=true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) & pausePanel.activeSelf == true)
        {
            Cursor.visible = false;
            ContinueGame();
        }
    }

    public void ContinueGame()
    {
        playerInput.enabled = true;
        helpPanel.SetActive(true);
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void OnClickFreeze()
    {
        if(Input.GetKeyDown(KeyCode.Q) & playerSettings.HairGel >= 3 )
        {
            textTimeFreeze.enabled = true;
            _hairGelSound.Play();
            playerMovement.OnAnimator("Stun", true);
            _timeAnim = 1;
            _timeFreeze = 10;
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
            textTimeFreeze.enabled = false;
            _freeze = false;            
            _stopAttack = 0.5f;
            _timeFreeze = 0;
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
