using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMoveHelp : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private GameObject _textBackground;
    [SerializeField] private Text Text;

    [Header("Scripts")]
    [SerializeField] private Cats cats;

    private void Start() 
    {
        _textBackground.GetComponent<GameObject>();
        FulText();  
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            Text.text = " ";            
            _textBackground.SetActive(false);    
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("JumpZone"))
        {
            Text.text = "Space - Прыжок";
            FulText();
            
        }

        if (collision.gameObject.CompareTag("AttackZone"))
        {
            Text.text = "ЛКМ - Стрелять";
            FulText();
        }

        if (collision.gameObject.CompareTag("2JumpZone"))
        {
            Text.text = "Space+Space - Двойной прыжок";
            FulText();
        }

        if (collision.gameObject.CompareTag("Cat1") & cats.TcepellinCat == false)
        {
            Text.text = "Вручи 1-го котика бабушке";
            FulText();
        }

        if (collision.gameObject.CompareTag("Cat2") & cats.OfeliyaCat == false)
        {
            Text.text = "Вручи 2-го котика бабушке";
            FulText();
        }

        if (collision.gameObject.CompareTag("Cat3") & cats.PryanicCat == false)
        {
            Text.text = "Вручи 3-го котика бабушке";
            FulText();
        }

        if (collision.gameObject.CompareTag("Cat1") & cats.TcepellinCat == true)
        {
            Text.text = "Спасибо тебе, внучек!";
            FulText();
        }

        if(collision.gameObject.CompareTag("Cat2") & cats.OfeliyaCat == true)
        {
            Text.text = "Спасибо тебе, внучек!";
            FulText();
        }

        if (collision.gameObject.CompareTag("Cat3") & cats.PryanicCat == true)
        {
            Text.text = "Спасибо тебе, внучек!";
            FulText();
        }

        if (collision.gameObject.CompareTag("Tcepellin"))
        {
            cats.TcepellinCat = true;
            Text.text = "Кажется, ты нашел первого котика";
            FulText();
            Destroy(collision.gameObject, 2);
        }

        if (collision.gameObject.CompareTag("Ofeliya"))
        {
            cats.OfeliyaCat = true;
            Text.text = "Кажется, ты нашел второго котика";
            FulText();
            Destroy(collision.gameObject, 2);
        }

        if (collision.gameObject.CompareTag("Pryanic"))
        {
            cats.PryanicCat = true;
            Text.text = "Кажется, ты нашел третьего котика";
            FulText();
            Destroy(collision.gameObject, 2);
        }
    }

    public void Texting(string text)
    {
        Text.text = text;
    }

    private void FulText()
    {
        _textBackground.SetActive(true);
    }

}
