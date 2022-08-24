using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMoveHelp : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private Text MoveText;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            MoveText.enabled = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
