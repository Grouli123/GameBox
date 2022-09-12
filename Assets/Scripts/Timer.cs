using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text _textTime;
    [SerializeField] private float _timeToEnd;

    public float endTime;


    private void Update() 
    {
        _timeToEnd -= Time.deltaTime;

        endTime = Mathf.RoundToInt(_timeToEnd);
        _textTime.text = endTime.ToString();

        if (_timeToEnd <= 0)
        {
            
           SceneManager.LoadScene(0);
        }
    }
}