using UnityEngine;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject _startMenu;
    [SerializeField] private GameObject _lvlMenu;
    
    private void Start()
    {
        _lvlMenu.SetActive(false);
        _startMenu.SetActive(true);
    }

    public void ChangeSceneMenu()
    {
        _lvlMenu.SetActive(true);
        _startMenu.SetActive(false);
    }
}
