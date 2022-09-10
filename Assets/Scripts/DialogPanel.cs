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

    private bool _hairGel = true;
    private bool _coins = true;
    private bool _cat = true;
    private bool _hpStation = true;
    private bool _enemy = true;

    private void Update()
    {
        EnemyPanel();
        OnClickMouse();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HairGelObject>() && _hairGel == true)
        {
            hairGelPanel.SetActive(true);
           // Time.timeScale = 0;
        }

        if(collision.gameObject.GetComponent<CoinCollectScript>() && _coins == true)
        {
            coinsPanel.SetActive(true);
            //Time.timeScale = 0;
        }

        if(collision.gameObject.CompareTag("ZoneAdvertisementTcepellin") && _cat == true)
        {
            catPanel.SetActive(true);
            //Time.timeScale = 0;
        }

        if(collision.gameObject.GetComponent<HPStation>() && _hpStation == true)
        {
            hpStationPanel.SetActive(true);
            //Time.timeScale = 0;
        }
    }

    private void EnemyPanel()
    {
        if (_enemy == true && enemyPanelMain.activeSelf == true)
        {
            //Time.timeScale = 0;
        }
        else if (_enemy == true && enemyPanelMain.activeSelf == true && Input.GetKeyDown(KeyCode.Mouse0)
            && enemyPanelJames.activeSelf == true)
        {
            enemyPanelJames.SetActive(false);
            enemyPanelCapitain.SetActive(true);
        }
        else if(_enemy == true && enemyPanelMain.activeSelf == true && Input.GetKeyDown(KeyCode.Mouse0)
            && enemyPanelCapitain.activeSelf == true)
        {
            enemyPanelCapitain.SetActive(false);
            enemyPanelJames2.SetActive(true);
        }
        else if(_enemy == true && enemyPanelMain.activeSelf == true && Input.GetKeyDown(KeyCode.Mouse0)
            && enemyPanelJames2.activeSelf == true)
        {
            _enemy = false;
            enemyPanelMain.SetActive(false);
        }
        else if(enemyPanelMain.activeSelf == true && Input.GetKeyDown(KeyCode.Mouse1))
        {
            _enemy = false;
            enemyPanelMain.SetActive(false);
        }
    }

    private void OnClickMouse()
    {
        if (hairGelPanel.activeSelf == true && _hairGel == true && Input.GetKeyDown(KeyCode.Mouse0))
        {
            _hairGel = false;
            Time.timeScale = 1;
            hairGelPanel.SetActive(false);
        }
        else if (hairGelPanel.activeSelf == true && _hairGel == true && Input.GetKeyDown(KeyCode.Mouse1))
        {
            _hairGel = false;
            Time.timeScale = 1;
            hairGelPanel.SetActive(false);
        }

        if (_coins == true && coinsPanel.activeSelf == true && Input.GetKeyDown(KeyCode.Mouse0))
        {
            coinsPanel.SetActive(false);
            Time.timeScale = 1;
            _coins = false;
        }
        else if (_coins == true && coinsPanel.activeSelf == true && Input.GetKeyDown(KeyCode.Mouse1))
        {
            coinsPanel.SetActive(false);
            Time.timeScale = 1;
            _coins = false;
        }

        if (_cat == true && catPanel.activeSelf == true && Input.GetKeyDown(KeyCode.Mouse0))
        {
            catPanel.SetActive(false);
            Time.timeScale = 1;
            _cat = false;
        }
        else if (_cat == true && catPanel.activeSelf == true && Input.GetKeyDown(KeyCode.Mouse1))
        {
            catPanel.SetActive(false);
            Time.timeScale = 1;
            _cat = false;
        }

        if (_hpStation == true && hpStationPanel.activeSelf == true && Input.GetKeyDown(KeyCode.Mouse0))
        {
            hpStationPanel.SetActive(false);
            Time.timeScale = 1;
            _hpStation = false;
        }
        else if (_hpStation == true && hpStationPanel.activeSelf == true && Input.GetKeyDown(KeyCode.Mouse1))
        {
            hpStationPanel.SetActive(false);
            Time.timeScale = 1;
            _hpStation = false;
        }
    }

    public void OnActivePanelEnemy(bool active)
    {
        enemyPanelMain.SetActive(active);
    }

    public bool Enemy
    {
        get { return _enemy; }
        set { _enemy = value; }
    }
}
