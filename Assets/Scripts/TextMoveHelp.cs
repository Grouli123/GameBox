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
    [SerializeField] private PlayerSettings playerSettings;

    private void Start() 
    {
        _textBackground.GetComponent<GameObject>();
        FulText(true);  
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            Text.text = " ";            
            _textBackground.SetActive(false);    
        }

        if(Input.GetKeyDown(KeyCode.B) & playerSettings.HairGel < 3)
        {
            Text.text = "Недостаточно геля";
            _textBackground.SetActive(true);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("JumpZone"))
        {
            Text.text = "Space - Прыжок";
            FulText(true);
            
        }

        if (collision.gameObject.CompareTag("AttackZone"))
        {
            Text.text = "ЛКМ - Стрелять";
            FulText(true);
        }

        if (collision.gameObject.CompareTag("2JumpZone"))
        {
            Text.text = "Space+Space - Двойной прыжок";
            FulText(true);
        }

        if (collision.gameObject.CompareTag("Cat1") & cats.TcepellinCat == false)
        {
            Text.text = "Вручи 1-го котика бабушке";
            FulText(true);
        }

        if (collision.gameObject.CompareTag("Cat2") & cats.OfeliyaCat == false)
        {
            Text.text = "Вручи 2-го котика бабушке";
            FulText(true);
        }

        if (collision.gameObject.CompareTag("Cat3") & cats.PryanicCat == false)
        {
            Text.text = "Вручи 3-го котика бабушке";
            FulText(true);
        }

        if (collision.gameObject.CompareTag("Cat1") & cats.TcepellinCat == true)
        {
            Text.text = "Спасибо тебе, внучек!";
            FulText(true);
        }

        if(collision.gameObject.CompareTag("Cat2") & cats.OfeliyaCat == true)
        {
            Text.text = "Спасибо тебе, внучек!";
            FulText(true);
        }

        if (collision.gameObject.CompareTag("Cat3") & cats.PryanicCat == true)
        {
            Text.text = "Спасибо тебе, внучек!";
            FulText(true);
        }

        if (collision.gameObject.CompareTag("Tcepellin"))
        {
            cats.TcepellinCat = true;
            Text.text = "Кажется, ты нашел первого котика";
            FulText(true);
            Destroy(collision.gameObject, 2);
        }

        if (collision.gameObject.CompareTag("Ofeliya"))
        {
            cats.OfeliyaCat = true;
            Text.text = "Кажется, ты нашел второго котика";
            FulText(true);
            Destroy(collision.gameObject, 2);
        }

        if (collision.gameObject.CompareTag("Pryanic"))
        {
            cats.PryanicCat = true;
            Text.text = "Кажется, ты нашел третьего котика";
            FulText(true);
            Destroy(collision.gameObject, 2);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("JumpZone"))
        {
            Text.text = " ";
            FulText(false);
        }

        if (collision.gameObject.CompareTag("AttackZone"))
        {
            Text.text = " ";
            FulText(false);
        }

        if (collision.gameObject.CompareTag("2JumpZone"))
        {
            Text.text = " ";
            FulText(false);
        }

        if (collision.gameObject.CompareTag("Cat1") & cats.TcepellinCat == false)
        {
            Text.text = " ";
            FulText(false);
        }

        if (collision.gameObject.CompareTag("Cat2") & cats.OfeliyaCat == false)
        {
            Text.text = " ";
            FulText(false);
        }

        if (collision.gameObject.CompareTag("Cat3") & cats.PryanicCat == false)
        {
            Text.text = " ";
            FulText(false);
        }

        if (collision.gameObject.CompareTag("Cat1") & cats.TcepellinCat == true)
        {
            Text.text = " ";
            FulText(false);
        }

        if (collision.gameObject.CompareTag("Cat2") & cats.OfeliyaCat == true)
        {
            Text.text = " ";
            FulText(false);
        }

        if (collision.gameObject.CompareTag("Cat3") & cats.PryanicCat == true)
        {
            Text.text = " ";
            FulText(false);
        }

        if (collision.gameObject.CompareTag("Tcepellin"))
        {
            Text.text = " ";
            FulText(false);
        }

        if (collision.gameObject.CompareTag("Ofeliya"))
        {
            Text.text = " ";
            FulText(false);
        }

        if (collision.gameObject.CompareTag("Pryanic"))
        {
            Text.text = " ";
            FulText(false);
        }
    }

    public void Texting(string text)
    {
        Text.text = text;
    }

    private void FulText(bool active)
    {
        _textBackground.SetActive(active);
    }

}
