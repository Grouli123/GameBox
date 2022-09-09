using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startcutscene : MonoBehaviour
{
    [SerializeField] private GameObject _scartCutscene;
    [SerializeField] private GameObject _firstSlide;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
        {
            _scartCutscene.SetActive(true);
            _firstSlide.SetActive(true);
        }
    }
}