using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text _textTime;
    [SerializeField] private float _timeToEnd;
    [SerializeField] private PlayerInput _playerInput;

    public float endTime;

    private void Update() 
    {
        
        Time.timeScale = 1;
        _timeToEnd -= Time.deltaTime;

        endTime = Mathf.RoundToInt(_timeToEnd);
        _textTime.text = endTime.ToString();

        if (_timeToEnd <= 0)
        {
            _playerInput.enabled = false;
           SceneManager.LoadScene(0);
        }
    }
}