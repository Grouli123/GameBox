using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text _textTime;
    [SerializeField] private float _timeToEnd;

    public int endTime;


    private void Update() 
    {
        _timeToEnd -= Time.deltaTime;

        endTime = Mathf.RoundToInt(_timeToEnd);
        _textTime.text = endTime.ToString();
    }
}
