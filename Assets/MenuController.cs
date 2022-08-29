using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _startPannel;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _startNewGame;
    [SerializeField] private GameObject _slot1;
    [SerializeField] private GameObject _nickname;
    [SerializeField] private GameObject _levelsAndCats;
    [SerializeField] private GameObject _levels;
    [SerializeField] private GameObject _dossier;

    // [SerializeField] private GameObject _loadGame;
    // [SerializeField] private GameObject _recordsPannel;
    // [SerializeField] private GameObject _settings;
    // [SerializeField] private GameObject _developersPannel;
    // [SerializeField] private GameObject _exitPannel;
    

    private void Start() 
    {
        _startPannel.SetActive(true);
        _mainMenu.SetActive(false);
        // _loadGame.SetActive(false);
        // _recordsPannel.SetActive(false);
        // _settings.SetActive(false);
        // _developersPannel.SetActive(false);
        // _exitPannel.SetActive(false);
    }

    public void StartGame()
    {
        _mainMenu.SetActive(true);
        _startPannel.SetActive(false);
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

    // public void LoadGame()
    // {
    //     _mainMenu.SetActive(false);
    //     _loadGame.SetActive(true);
    // }

    // public void Records()
    // {
    //     _mainMenu.SetActive(false);
    //     _recordsPannel.SetActive(true);
    // }

    // public void Settings()
    // {
    //     _mainMenu.SetActive(false);
    //     _settings.SetActive(true);
    // }

    // public void Developers()
    // {
    //     _mainMenu.SetActive(false);
    //     _developersPannel.SetActive(true);
    // }

    // public void Exit()
    // {
    //     _mainMenu.SetActive(false);
    //     _exitPannel.SetActive(true);
    // }
}
