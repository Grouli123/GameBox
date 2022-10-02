using UnityEngine;
using UnityEngine.UI;

public class DialogPanel : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject hairGelPanel;
    [SerializeField] private GameObject coinsPanel;
    [SerializeField] private GameObject catPanel;
    [SerializeField] private GameObject hpStationPanel;
    [SerializeField] private GameObject enemyPanelMain;
    [SerializeField] private GameObject enemyPanelJames;
    [SerializeField] private GameObject enemyPanelCapitain;
    [SerializeField] private GameObject enemyPanelJames2;

    [Header("Sound")]
    [SerializeField] private AudioClip[] sound;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioSource runStone;
    [SerializeField] private AudioSource runMetall;
    
    [Header("Other")]
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Animator _anim;
    [SerializeField] private Text timeGame;
    [SerializeField] private Text timeSeconds;
    [SerializeField] private Text timeDelta;
    private float _timeMinutes;
    private float _timeSeconds;

   // [SerializeField] private GameObject _timerStart;

    private bool _hairGel = true;
    private bool _coins = true;
    private bool _cat = true;
    private bool _hpStation = true;
    private bool _enemy = true;

    private void Start()
    {
        //timeGame.enabled = false;
        //timeSeconds.enabled = false;
        //timeDelta.enabled = false;
    }
    private void Awake() 
    {
        _anim = GetComponent<Animator>();
    }
    private void Update()
    {
        TimeGameActive();
        EnemyPanel();
        OnClickMouse();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HairGelObject>() & _hairGel == true)
        {
            runStone.volume = 0f;
            source.clip = sound[1];
            source.Play();
            hairGelPanel.SetActive(true);
            playerInput.enabled = false;
            _anim.SetBool("IsRun", false);            
            _anim.SetBool("IsJump", false);
           Time.timeScale = 0;
        }

        if(collision.gameObject.GetComponent<CoinCollectScript>() & _coins == true)
        {
            runStone.volume = 0f;
            source.clip = sound[0];
            source.Play();
            coinsPanel.SetActive(true);
            playerInput.enabled = false;
            _anim.SetBool("IsRun", false);            
            _anim.SetBool("IsJump", false);
            Time.timeScale = 0;
        }

        if(collision.gameObject.CompareTag("ZoneAdvertisementTcepellin") & _cat == true)
        {
            runStone.volume = 0f;
            source.clip = sound[2];
            source.Play();
            catPanel.SetActive(true);
            playerInput.enabled = false;
            _anim.SetBool("IsRun", false);            
            _anim.SetBool("IsJump", false);
            Time.timeScale = 0;
        }

        if(collision.gameObject.GetComponent<HPStation>() & _hpStation == true)
        {
            runMetall.volume = 0f;
            source.clip = sound[3];
            source.Play();
            hpStationPanel.SetActive(true);
            playerInput.enabled = false;
            _anim.SetBool("IsRun", false);            
            _anim.SetBool("IsJump", false);
            Time.timeScale = 0;
        }
    }

    private void EnemyPanel()
    {
        if (_enemy == true & enemyPanelMain.activeSelf == true & Input.GetKeyDown(KeyCode.Mouse1)
            & enemyPanelJames.activeSelf == true)
        {
            //_timerStart.SetActive(true);
            source.clip = sound[5];
            source.Play();
            playerInput.enabled = false;
            _anim.SetBool("IsRun", false);
            _anim.SetBool("IsJump", false);
            Time.timeScale = 0;
            enemyPanelJames.SetActive(false);
            enemyPanelCapitain.SetActive(true);
        }
        else if(_enemy == true & enemyPanelMain.activeSelf == true & Input.GetKeyDown(KeyCode.Mouse1)
            & enemyPanelCapitain.activeSelf == true)
        {
            _timeSeconds = 0;
            _timeMinutes = 15;
            timeGame.text = _timeMinutes.ToString();
            source.clip = sound[6];
            source.Play();
            playerInput.enabled = false;
            _anim.SetBool("IsRun", false);
            _anim.SetBool("IsJump", false);
            Time.timeScale = 0;
            enemyPanelCapitain.SetActive(false);
            enemyPanelJames2.SetActive(true);
        }
        else if(_enemy == true & enemyPanelMain.activeSelf == true & Input.GetKeyDown(KeyCode.Mouse1)
            & enemyPanelJames2.activeSelf == true)
        {
            source.Stop();
            _enemy = false;
            playerInput.enabled = true;
            Time.timeScale = 1;
            enemyPanelMain.SetActive(false);
        }
    }

    private void OnClickMouse()
    {
        if (hairGelPanel.activeSelf == true & _hairGel == true & Input.GetKeyDown(KeyCode.Mouse1))
        {
            runStone.volume = 1f;
            source.Stop();
            _hairGel = false;
            playerInput.enabled = true;
            Time.timeScale = 1;
            hairGelPanel.SetActive(false);
        }

        if (_coins == true & coinsPanel.activeSelf == true & Input.GetKeyDown(KeyCode.Mouse1))
        {
            runStone.volume = 1f;
            source.Stop();
            coinsPanel.SetActive(false);
            playerInput.enabled = true;
            Time.timeScale = 1;
            _coins = false;
        }

        if (_cat == true & catPanel.activeSelf == true & Input.GetKeyDown(KeyCode.Mouse1))
        {
            runStone.volume = 1f;
            source.Stop();
            catPanel.SetActive(false);
            playerInput.enabled = true;
            Time.timeScale = 1;
            _cat = false;
        }

        if (_hpStation == true & hpStationPanel.activeSelf == true & Input.GetKeyDown(KeyCode.Mouse1))
        {
            source.Stop();
            hpStationPanel.SetActive(false);
            playerInput.enabled = true;
            Time.timeScale = 1;
            _hpStation = false;
        }
    }

    private void TimeGameActive()
    {
        if(_enemy == false)
        {
            //timeGame.enabled = true;
            //timeSeconds.enabled = true;
            //timeDelta.enabled = true;
            timeGame.text = _timeMinutes.ToString();
            timeSeconds.text = Mathf.Round(_timeSeconds).ToString();
            _timeSeconds -= Time.deltaTime;
            if(_timeSeconds < 0)
            {
                _timeMinutes -= 1;
                _timeSeconds = 59;
            }

            if(_timeMinutes <= 0)
            {
                _timeSeconds = 0;
                _timeMinutes = 0;
                timeGame.color = new Color(255,0,0);
                timeSeconds.color = new Color(255,0,0);
                timeDelta.color = new Color(255,0,0);
            }
        }

    }

    public void OnActivePanelEnemy(bool active)
    {
        enemyPanelMain.SetActive(active);
    }

    public void SoundPanelEnemy(int number)
    {
        source.clip = sound[number];
        source.Play();
    }

    public void TimeScale(int time)
    {
        Time.timeScale = time;
    }
    
    public bool Enemy
    {
        get { return _enemy; }
        set { _enemy = value; }
    }
}
