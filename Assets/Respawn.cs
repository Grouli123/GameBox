using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Scriptable;

public class Respawn : MonoBehaviour
{
    [SerializeField] private IntegerVariable _coinScore;
    [SerializeField] private IntegerVariable _casseteScore;
    [SerializeField] private IntegerVariable _allScore;    
    [SerializeField] private GameObject _deathPannelTwo;
    [SerializeField] private PlayerSettings _playerSettings;

    //[SerializeField] private int _coinsForRespawn;

    public void OnClickButton()
    {
        if (_coinScore.GetValue() >= 0)
        {
            _allScore.SetValue(0);
            _coinScore.SetValue(0);
            _casseteScore.SetValue(3);
            _deathPannelTwo.SetActive(false);        
            _playerSettings.Hp = 10;
            _playerSettings.Cassete = 3;
            Time.timeScale = 1;
        }
    }
}