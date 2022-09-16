using UnityEngine;
using UnityEngine.UI;

public class TimerToEnd : MonoBehaviour
{
    [SerializeField] private Text _textTime;
    [SerializeField] private float _timeToEnd;

    public float endTimeToUpScore;

    private void Update() 
    {
        
        Time.timeScale = 1;
        _timeToEnd -= Time.deltaTime;

        endTimeToUpScore = Mathf.RoundToInt(_timeToEnd);
        _textTime.text = endTimeToUpScore.ToString();

        // if (_timeToEnd <= 0)
        // {

        // }
    }
}
