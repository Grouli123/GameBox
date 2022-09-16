using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Scriptable;

public class Respawn : MonoBehaviour
{
    [SerializeField] private IntegerVariable _coinScore;
    [SerializeField] private GameObject _deathPannelTwo;
    [SerializeField] private PlayerSettings _playerSettings;

    //[SerializeField] private int _coinsForRespawn;

    public void OnClickButton()
    {
        if (_coinScore.GetValue() >= 1)
        {
            _coinScore.SetValue(0);
            _deathPannelTwo.SetActive(false);        
            _playerSettings.Hp = 10;
            Time.timeScale = 1;
        }
    }
}