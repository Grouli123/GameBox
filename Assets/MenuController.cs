using UnityEngine;
using UnityEngine.UI;
using Scriptable;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _globalNewGame;
    [SerializeField] private GameObject _globalLoadGame;
    [SerializeField] private GameObject _recordsPannel;
    [SerializeField] private GameObject _settings;
    [SerializeField] private GameObject _developersPannel;
    [SerializeField] private GameObject _exitPannel;

    [SerializeField] private Button _selectStartButton;
    [SerializeField] private Button _selectNewGameButton;
    [SerializeField] private Button _selectSlotOneSaveButton;    
    [SerializeField] private Button _selectYesSaveButton;
    [SerializeField] private Button _selectNicknameSaveButton;
    [SerializeField] private Button _selectLevelSaveButton;


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

    private bool _isStartGame = false;
    private bool _isNewGameIn = false;
    private bool _isSelectPannelSaveMenu = false;
    private bool _isWriteNickname = false;
    private bool _isInLevels = false;
    private bool _isCatsDosieOn = false;
    private bool _isLevelsOn = false;



    private bool _isLoadGame = false;
    private bool _isSelectPannelLoadMenu = false;
    private bool _isCatsDosieLoadOn = false;
    private bool _isLevelsLoadOn = false;
    private bool _isRecords = false;
    private bool _isInSettings = false;
    private bool _isInDevelopers = false;
    private bool _isInExit = false;

    [SerializeField] private GameObject _emptydosie;
    [SerializeField] private GameObject _firstcatdosie;
    [SerializeField] private GameObject _secondcatdosie;    
    [SerializeField] private GameObject _thirdcatdosie;
    [SerializeField] private GameObject _fourthtcatdosie;
    [SerializeField] private GameObject _fithcatdosie;

    private void Start() 
    {
        if (AgainStartMenu.startMainMenu == true)
        {
           StartGame();
        } 
        else
        {
            _startPannel.SetActive(true);
            _mainMenu.SetActive(false);
            _selectStartButton.Select();
        }

        _globalNewGame.SetActive(true);
        _globalLoadGame.SetActive(false);
        _recordsPannel.SetActive(false);
        _settings.SetActive(false);
        _developersPannel.SetActive(false);
        _exitPannel.SetActive(false);

        

        
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

        // if (Input.GetKey(KeyCode.Return)) 
        // {      
        //     _startPannel.SetActive(false);
        //     _mainMenu.SetActive(true);
        // }   




        if (Input.GetKey(KeyCode.Escape) && _isNewGameIn == true)
        {
            _mainMenu.SetActive(true);
            _startNewGame.SetActive(false);
            _isNewGameIn = false;
        }

        if (Input.GetKey(KeyCode.Escape) && _isSelectPannelSaveMenu == true)
        {
            _mainMenu.SetActive(true);
            _startNewGame.SetActive(false);
            _slot1.SetActive(false);
            _slot1.SetActive(false);
            _nickname.SetActive(false);
            _nickname.SetActive(false);
            _levelsAndCats.SetActive(false);
            _saveLevelsTopButtons.SetActive(false);
            _levels.SetActive(false);
            _isSelectPannelSaveMenu = false;
        }

        if (Input.GetKey(KeyCode.E) && _isCatsDosieOn == true)
        {
            _levels.SetActive(false);
            _dossier.SetActive(true);
            _isCatsDosieOn = false;
            _isLevelsOn = true;
        }

        if (Input.GetKey(KeyCode.Q) && _isLevelsOn == true)
        {
            _levels.SetActive(true);
            _dossier.SetActive(false);
            _isLevelsOn = false;
            _isCatsDosieOn = true;
        }


        if (Input.GetKey(KeyCode.Escape) && _isSelectPannelSaveMenu == true)
        {
            _slot1.SetActive(true);
            _nickname.SetActive(false);
            _isSelectPannelSaveMenu = false;
            
        _selectSlotOneSaveButton.Select();
        }
        
        // if (Input.GetKey(KeyCode.Backspace) && _isWriteNickname == true)
        // {
        //     _slot1.SetActive(true);
        //     _nickname.SetActive(false);
        //     _isWriteNickname = false;
        // }
        // if (Input.GetKey(KeyCode.Backspace) && _isInLevels == true)
        // {
        //     _nickname.SetActive(true);
        //     _levelsAndCats.SetActive(false);
        //     _saveLevelsTopButtons.SetActive(false);
        //     _levels.SetActive(false);
        //     _isInLevels = false;
        // }








        if (Input.GetKey(KeyCode.Escape) && _isLoadGame == true)
        {
            _mainMenu.SetActive(true);
            _globalLoadGame.SetActive(false);
            _loadGame.SetActive(false);
            _isLoadGame = false;
        }

         if (Input.GetKey(KeyCode.Escape) && _isSelectPannelLoadMenu == true)
        {
            _mainMenu.SetActive(true);
            _loadGame.SetActive(false);
            _selectPanelSave.SetActive(false);
            _loadLevelsAndDossier.SetActive(false);
            _loadLevelSelectPanel.SetActive(false);
            _loadCatsDosiePanel.SetActive(false);
        }

        if (Input.GetKey(KeyCode.E) && _isCatsDosieLoadOn == true)
        {
            _loadLevelSelectPanel.SetActive(false); 
            _loadCatsDosiePanel.SetActive(true);  
            _isCatsDosieLoadOn = false;
            _isLevelsLoadOn = true;
        }

        if (Input.GetKey(KeyCode.Q) && _isLevelsLoadOn == true)
        {
            _loadLevelSelectPanel.SetActive(true); 
            _loadCatsDosiePanel.SetActive(false); 
            _isLevelsLoadOn = false;
            _isCatsDosieLoadOn = true;
        }







        if (Input.GetKey(KeyCode.Escape) && _isRecords == true)
        {
            _mainMenu.SetActive(true);
            _recordsPannel.SetActive(false);
            _isRecords = false;
        }

        if (Input.GetKey(KeyCode.Escape) && _isInSettings == true)
        {
            _mainMenu.SetActive(true);
            _settings.SetActive(false);
            _isInSettings = false;
        }

        if (Input.GetKey(KeyCode.Escape) && _isInDevelopers == true)
        {
            _mainMenu.SetActive(true);
            _developersPannel.SetActive(false);
            _isInDevelopers = false;
        }

        if (Input.GetKey(KeyCode.Escape) && _isInExit == true)
        {
            _mainMenu.SetActive(true);
            _exitPannel.SetActive(false);
            _isInExit = false;
        }






        // if (Input.GetKey(KeyCode.Return) && _isStartGame == true)
        // {
        //     StartNewGame();
        // }
    }

    public void StartGame()
    {
        _startPannel.SetActive(false);
        _mainMenu.SetActive(true);
            
        _isStartGame = true;    
        _selectNewGameButton.Select();
    }

    public void StartNewGame()
    {
        _mainMenu.SetActive(false);
        _startNewGame.SetActive(true);
        _isNewGameIn = true;
    }

    public void Slot1() 
    {        
        _startNewGame.SetActive(false);
        _slot1.SetActive(true);
        _isSelectPannelSaveMenu = true;
    }

    public void SlotsYes()
    {
        _slot1.SetActive(false);
        _nickname.SetActive(true);        
        _isWriteNickname = true;
        _selectYesSaveButton.Select();
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
        _isInLevels = true;
        _isCatsDosieOn = true;
        _selectNicknameSaveButton.Select();
    }

    public void CatsDossier()
    {        
        _levels.SetActive(false);
        _dossier.SetActive(true);
        _isLevelsOn = true;
        _emptydosie.SetActive(true);
        _firstcatdosie.SetActive(false);
        _secondcatdosie.SetActive(false);
        _thirdcatdosie.SetActive(false);
        _fourthtcatdosie.SetActive(false);
        _fithcatdosie.SetActive(false);
    }

    public void firstcat()
    {
        _emptydosie.SetActive(false);
        _firstcatdosie.SetActive(true);
        _secondcatdosie.SetActive(false);
        _thirdcatdosie.SetActive(false);
        _fourthtcatdosie.SetActive(false);
        _fithcatdosie.SetActive(false);
    }

    public void secondcat()
    {
        _emptydosie.SetActive(false);
        _firstcatdosie.SetActive(false);
        _secondcatdosie.SetActive(true);
        _thirdcatdosie.SetActive(false);
        _fourthtcatdosie.SetActive(false);
        _fithcatdosie.SetActive(false);
    }

    public void thirdcat()
    {
        _emptydosie.SetActive(false);
        _firstcatdosie.SetActive(false);
        _secondcatdosie.SetActive(false);
        _thirdcatdosie.SetActive(true);
        _fourthtcatdosie.SetActive(false);
        _fithcatdosie.SetActive(false);
    }

    public void fourthcat()
    {
        _emptydosie.SetActive(false);
        _firstcatdosie.SetActive(false);
        _secondcatdosie.SetActive(false);
        _thirdcatdosie.SetActive(false);
        _fourthtcatdosie.SetActive(true);
        _fithcatdosie.SetActive(false);
    }

    public void fithcat()
    {
        _emptydosie.SetActive(false);
        _firstcatdosie.SetActive(false);
        _secondcatdosie.SetActive(false);
        _thirdcatdosie.SetActive(false);
        _fourthtcatdosie.SetActive(false);
        _fithcatdosie.SetActive(true);
    }

    public void Levels()
    {
        _dossier.SetActive(false);
        _levels.SetActive(true);
        _isCatsDosieOn = true;
        _selectLevelSaveButton.Select();
    }

    public void LoadGame()
    {
        _mainMenu.SetActive(false);
        _globalLoadGame.SetActive(true);
        _loadGame.SetActive(true);

        _isLoadGame = true;
    }

    public void Records()
    {
        _mainMenu.SetActive(false);
        _recordsPannel.SetActive(true);

        _isRecords = true;
    }

    public void Settings()
    {
        _mainMenu.SetActive(false);
        _settings.SetActive(true);
        _isInSettings = true;
    }

    public void Developers()
    {
        _mainMenu.SetActive(false);
        _developersPannel.SetActive(true);
        _isInDevelopers = true;
    }

    public void Exit()
    {
        _mainMenu.SetActive(false);
        _exitPannel.SetActive(true);
        _isInExit = true;
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
        _isSelectPannelLoadMenu = true;
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
        
        _isCatsDosieLoadOn = true;        
    }

    public void LoadLevels()
    {
        _loadCatsDosiePanel.SetActive(false);
        _loadLevelSelectPanel.SetActive(true);
        _isCatsDosieLoadOn = true;        
    }

     public void LoadCatsAndDosie()
    {
        _loadLevelSelectPanel.SetActive(false); 
        _loadCatsDosiePanel.SetActive(true);   
        _isLevelsLoadOn = true;    
    }
}