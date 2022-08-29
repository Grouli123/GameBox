using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPStation : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private TextMoveHelp textMoveHelp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            textMoveHelp.Texting("ֽאזלטעו ֵ");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") & Input.GetKey(KeyCode.E))
        {
            playerSettings.Hp = 10;
            Destroy(gameObject, 2);
        }
    }
}
