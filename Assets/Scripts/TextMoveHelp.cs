using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMoveHelp : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private Text Text;

    [Header("Scripts")]
    [SerializeField] private Cats cats;

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

        if (collision.gameObject.CompareTag("Cat1") & cats.TcepellinCat == false)
        {
            Text.text = "����� 1-�� ������ �������";
        }

        if(collision.gameObject.CompareTag("Cat1") & cats.TcepellinCat == true)
        {
            Text.text = "�� ������� ���� ������!";
            Destroy(collision.gameObject, 3);
        }

        if (collision.gameObject.CompareTag("Tcepellin"))
        {
            cats.TcepellinCat = true;
            Text.text = "������� �� ����� ������� ������";
            Destroy(collision.gameObject, 3);
        }
    }
}
