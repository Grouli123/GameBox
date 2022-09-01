using UnityEngine;

public class ButtonForGame : MonoBehaviour
{
    [Header("scripts")]
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private EnemyController enemyController;

    [Header("Objects")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject helpPanel;

    private bool _pauseActive;
    private float _timeFreeze;
    private bool _freeze;

    private void Start()
    {        
        Time.timeScale = 1;
        _pauseActive = false;
        _freeze = false;
    }

    private void Update()
    {
        _timeFreeze -= Time.deltaTime;
        OnClickPause();
        OnClickFreeze();
    }
    public void OnClickPause()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (_pauseActive == false)
            {
                helpPanel.SetActive(false);
                _pauseActive = true;
                Time.timeScale = 0;
                pausePanel.SetActive(true);
            }
            else
            {
                ContinueGame();
            }
        }
    }

    public void ContinueGame()
    {
        helpPanel.SetActive(true);
        _pauseActive = false;
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void OnClickFreeze()
    {
        if(Input.GetKeyDown(KeyCode.B) & playerSettings.HairGel == 3 )
        {
            _timeFreeze = 5;
            _freeze = true;
            playerSettings.HairGel = 0;
        }

        if (_timeFreeze < 0)
        {
            _freeze = false;
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
