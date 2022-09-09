using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstLvlStartCutscene : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private GameObject _James;
    [SerializeField] private GameObject _Shef;

    private string _dialog;
    private void Start() 
    {
        _dialog = "Добрый вечер, шеф. Вы хотели меня видеть?";
        _dialog = "Так точно, мой мальчик. Проходи, садись";
        
        
        StartCoroutine(OutputText(_dialog, 0.1f));
        
    }

    IEnumerator OutputText(string str, float delay)
    {
        foreach (var sym in str)
        {
            _text.text += sym;

            yield return new WaitForSeconds(delay);
        }
    }
}