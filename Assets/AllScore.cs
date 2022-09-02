using Scriptable;
using UnityEngine;
using UnityEngine.UI;

public class AllScore : MonoBehaviour
{
    [SerializeField] private IntegerVariable _allOfScore;
    [SerializeField] private Text _scoreHeroText;

    private void Start() 
    {
        _allOfScore.SetValue(0);
    }
    
    private void Update() 
    {        
        _scoreHeroText.text = _allOfScore.GetValue().ToString();
    }
}
