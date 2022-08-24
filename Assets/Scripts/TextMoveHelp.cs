using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMoveHelp : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private Text Text;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            Text.text = " ";
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("JumpZone"))
        {
            Text.text = "Space - ������";
        }

        if (collision.gameObject.CompareTag("AttackZone"))
        {
            Text.text = "��� - ��������";
        }

        if (collision.gameObject.CompareTag("2JumpZone"))
        {
            Text.text = "Space+Space - ������� ������";
        }

        if (collision.gameObject.CompareTag("Cat1"))
        {
            Text.text = "����� 1-�� ������ �������";
        }
    }
}
