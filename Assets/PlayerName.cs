using ScriptablePlayerStats;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    [SerializeField] private SavePlayerStats _playerName;
    [SerializeField] private Button _btnClick;

    [SerializeField] private InputField _inputUser;
    private string _input;

    private void Start() 
    {
        _btnClick.onClick.AddListener(ReadStringInput);
    }

    public void ReadStringInput()
    {
        _input = _inputUser.text;
        _playerName.SetValue(_input);
        // _input = s;
        // Debug.Log(_input);
        // _playerName.SetValue(_input);
    }
}
