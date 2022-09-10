using UnityEngine;
using Scriptable;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _globalNewGame;
    [SerializeField] private GameObject _globalLoadGame;
    [SerializeField] private GameObject _recordsPannel;
    [SerializeField] private GameObject _settings;
    [SerializeField] private GameObject _developersPannel;
    [SerializeField] private GameObject _exitPannel;


    [SerializeField] private GameObject _startPannel;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _startNewGame;
    [SerializeField] private GameObject _slot1;
    [SerializeField] private GameObject _nickname;
    [SerializeField] private GameObject _levelsAndCats;
    [SerializeField] private GameObject _levels;
    [SerializeField] private GameObject _saveLevelsTopButtons;
    [SerializeField] private GameObject _dossier;

    [SerializeField] private GameObject _loadGame;
    [SerializeField] private GameObject _selectPanelSave;
    [SerializeField] private GameObject _loadLevelsAndDossier;
    [SerializeField] private GameObject _loadLevelSelectPanel;
    [SerializeField] private GameObject _loadCatsDosiePanel;

    [SerializeField] private IntegerVariable _cassete;

    private void Start() 
    {
        _globalNewGame.SetActive(true);
        _globalLoadGame.SetActive(false);
        _recordsPannel.SetActive(false);
        _settings.SetActive(false);
        _developersPannel.SetActive(false);
        _exitPannel.SetActive(false);

        _startPannel.SetActive(true);
        _mainMenu.SetActive(false);
        _startNewGame.SetActive(false);
        _slot1.SetActive(false);
        _nickname.SetActive(false);
        _levelsAndCats.SetActive(false);
        _levels.SetActive(false);
        _saveLevelsTopButtons.SetActive(false);
        _dossier.SetActive(false);

        _loadGame.SetActive(false);
        _selectPanelSave.SetActive(false);
        _loadLevelsAndDossier.SetActive(false);
        _loadLevelSelectPanel.SetActive(false);
        _loadCatsDosiePanel.SetActive(false);
    }

    private void Update() 
    {   
        if (AgainStartMenu.startMainMenu == true)
        {
            _startPannel.SetActive(false);
            _mainMenu.SetActive(true);
        }     

        if (Input.GetKey(KeyCode.Return)) 
        {      
            _startPannel.SetActive(false);
            _mainMenu.SetActive(true);
        }   
    }

    public void StartGame()
    {
        _startPannel.SetActive(false);
        _mainMenu.SetActive(true);
    }

    public void StartNewGame()
    {
        _mainMenu.SetActive(false);
        _startNewGame.SetActive(true);
    }

    public void Slot1() 
    {        
        _startNewGame.SetActive(false);
        _slot1.SetActive(true);
    }

    public void SlotsYes()
    {
        _slot1.SetActive(false);
        _nickname.SetActive(true);
    }

    public void SlotsNo()
    {
        _slot1.SetActive(false);
        _startNewGame.SetActive(true);
    }

    public void NextWindowNickname()
    {
        _nickname.SetActive(false);
        _levelsAndCats.SetActive(true);
        _saveLevelsTopButtons.SetActive(true);
        _levels.SetActive(true);
    }

    public void CatsDossier()
    {        
        _levels.SetActive(false);
        _dossier.SetActive(true);
    }

    public void Levels()
    {
        _dossier.SetActive(false);
        _levels.SetActive(true);
    }

    public void LoadGame()
    {
        _mainMenu.SetActive(false);
        _globalLoadGame.SetActive(true);
        _loadGame.SetActive(true);
    }

    public void Records()
    {
        _mainMenu.SetActive(false);
        _recordsPannel.SetActive(true);
    }

    public void Settings()
    {
        _mainMenu.SetActive(false);
        _settings.SetActive(true);
    }

    public void Developers()
    {
        _mainMenu.SetActive(false);
        _developersPannel.SetActive(true);
    }

    public void Exit()
    {
        _mainMenu.SetActive(false);
        _exitPannel.SetActive(true);
    }

    public void ExitTurnBack()
    {
        _exitPannel.SetActive(false);
        _mainMenu.SetActive(true);
    }

    public void LoadSlot1()
    {
        _loadGame.SetActive(false);
        _selectPanelSave.SetActive(true);
    }

    public void LoadSlotsTurnBack()
    {
        _selectPanelSave.SetActive(false);
        _loadGame.SetActive(true);
    }

    public void LoadLevelAndDossier()
    {
        _selectPanelSave.SetActive(false);
        _loadCatsDosiePanel.SetActive(false);
        _loadLevelsAndDossier.SetActive(true);
        _loadLevelSelectPanel.SetActive(true);
    }

    public void LoadLevels()
    {
        _loadCatsDosiePanel.SetActive(false);
        _loadLevelSelectPanel.SetActive(true);        
    }

     public void LoadCatsAndDosie()
    {
        _loadLevelSelectPanel.SetActive(false); 
        _loadCatsDosiePanel.SetActive(true);       
    }
}