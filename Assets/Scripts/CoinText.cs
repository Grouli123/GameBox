using Scriptable;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    [SerializeField] private IntegerVariable _lvlScore;
    
    private Text _scoreTextField;

    private void Start()
    { 
        _scoreTextField = GetComponent<Text>();
        _lvlScore.Listeners += UpdateTextField;
        UpdateTextField(_lvlScore.GetValue());
    }


    private void OnDestroy() 
    {
        _lvlScore.Listeners -= UpdateTextField;
    }

    private void UpdateTextField(int value)
    {
        _scoreTextField.text = value.ToString();
    }
}