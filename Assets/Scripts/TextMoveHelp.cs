using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMoveHelp : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private GameObject _textBackground;
    [SerializeField] private Text Text;
    [SerializeField] private Text catScoreText;

    [Header("Scripts")]
    [SerializeField] private Cats cats;
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private BafHero bafHero;

    [Header("Other")]
    [SerializeField] private Image advertisement;
    [SerializeField] private Sprite[] advertisementSprite; 

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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            advertisement.gameObject.SetActive(false);
            FulText(false);
        }

        catScoreText.text = cats.CatScore.ToString();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ZoneAdvertisementTcepellin"))
        {
            Text.text = "Нажмите Е";
            FulText(true);
        }

        if (collision.gameObject.CompareTag("ZoneAdvertisementVurdalak"))
        {
            Text.text = "Нажмите Е";
            FulText(true);
        }

        if (collision.gameObject.CompareTag("ZoneAdvertisementUri"))
        {
            Text.text = "Нажмите Е";
            FulText(true);
        }

        if (collision.gameObject.CompareTag("ZoneAdvertisementOfeliya"))
        {
            Text.text = "Нажмите Е";
            FulText(true);
        }

        if (collision.gameObject.CompareTag("ZoneAdvertisementPryanic"))
        {
            Text.text = "Нажмите Е";
            FulText(true);
        }

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
            Text.text = "Где же мой Цеппелин?";
            FulText(true);
        }

        if (collision.gameObject.CompareTag("Cat2") & cats.OfeliyaCat == false)
        {
            Text.text = "Ох, где моя Офелия?";
            FulText(true);
        }

        if (collision.gameObject.CompareTag("Cat3") & cats.PryanicCat == false)
        {
            Text.text = "Наверное, мой Пряник в беде...";
            FulText(true);
        }

        if (collision.gameObject.CompareTag("Cat4") & cats.VurdalakCat == false)
        {
            Text.text = "Вурдалак мой на охоту сбежал...";
            FulText(true);
        }

        if (collision.gameObject.CompareTag("Cat5") & cats.UriCat == false)
        {
            Text.text = "Кажется, моя Ури убежала в подвал.";
            FulText(true);
        }

        if (collision.gameObject.CompareTag("Cat1") & cats.TcepellinCat == true)
        {
            Text.text = "Спасибо тебе, внучок! Держи усиление урона!";
            FulText(true);
            bafHero.onDoubleDamage = true;
            cats.CatScore += 1;
        }

        if(collision.gameObject.CompareTag("Cat2") & cats.OfeliyaCat == true)
        {
            Text.text = "Святой гигабайт, спасибо тебе! С меня ускоритель пушки!";
            FulText(true);
            bafHero.onDoubleSpeed = true;
            cats.CatScore += 1;
        }

        if (collision.gameObject.CompareTag("Cat3") & cats.PryanicCat == true)
        {
            Text.text = "Спасибо, внучек! Держи супер-прыжок!";
            FulText(true);
            bafHero.onDoubleJump = true;
            cats.CatScore += 1;
        }

        if (collision.gameObject.CompareTag("Cat4") & cats.VurdalakCat == true)
        {
            Text.text = "Божечки-кошечки, спасибо тебе! Теперь ты будешь богат!";
            FulText(true);
            bafHero.onDoubleCoins = true;
            cats.CatScore += 1;
        }

        if (collision.gameObject.CompareTag("Cat5") & cats.UriCat == true)
        {
            Text.text = "Моя дорогая Ури! Держи витаминку на 150% здоровья!";
            FulText(true);
            bafHero.onDobleLives = true;
            cats.CatScore += 1;
            playerSettings.Hp = 15;
            playerSettings.OnDoubleLives = true;
        }

        if (collision.gameObject.CompareTag("Tcepellin") & cats.TcepellinAdvertisement == true)
        {
            cats.TcepellinCat = true;
            Text.text = "Кажется, ты нашел первого котика";
            FulText(true);
            Destroy(collision.gameObject, 2);
        }

        if (collision.gameObject.CompareTag("Ofeliya") & cats.OfeliyaAdvertisement == true)
        {
            cats.OfeliyaCat = true;
            Text.text = "Кажется, ты нашел второго котика";
            FulText(true);
            Destroy(collision.gameObject, 2);
        }

        if (collision.gameObject.CompareTag("Pryanic") & cats.PryanicAdvertisement == true)
        {
            cats.PryanicCat = true;
            Text.text = "Кажется, ты нашел третьего котика";
            FulText(true);
            Destroy(collision.gameObject, 2);
        }

        if (collision.gameObject.CompareTag("Vurdalak") & cats.VurdalakAdvertisement == true)
        {
            cats.VurdalakCat = true;
            Text.text = "Кажется, ты нашел третьего котика";
            FulText(true);
            Destroy(collision.gameObject, 2);
        }

        if (collision.gameObject.CompareTag("Uri") & cats.VurdalakAdvertisement == true)
        {
            cats.VurdalakCat = true;
            Text.text = "Кажется, ты нашел третьего котика";
            FulText(true);
            Destroy(collision.gameObject, 2);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ZoneAdvertisementTcepellin"))
        {
            advertisement.gameObject.SetActive(false);
            Text.text = " ";
            FulText(false);
        }

        if (collision.gameObject.CompareTag("ZoneAdvertisementOfeliya"))
        {
            advertisement.gameObject.SetActive(false);
            Text.text = " ";
            FulText(false);
        }

        if (collision.gameObject.CompareTag("ZoneAdvertisementPryanic"))
        {
            advertisement.gameObject.SetActive(false);
            Text.text = " ";
            FulText(false);
        }

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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ZoneAdvertisementTcepellin") & Input.GetKeyDown(KeyCode.E))
        {
            //Text.text = "Esc - закрыть";
            //FulText(true);
            advertisement.gameObject.SetActive(true);
            advertisement.sprite = advertisementSprite[0];
            cats.TcepellinAdvertisement = true;
        }

        if (collision.gameObject.CompareTag("ZoneAdvertisementOfeliya") & Input.GetKeyDown(KeyCode.E))
        {
            //Text.text = "Esc - закрыть";
           // FulText(true);
            advertisement.gameObject.SetActive(true);
            advertisement.sprite = advertisementSprite[1];
            cats.OfeliyaAdvertisement = true;
        }

        if (collision.gameObject.CompareTag("ZoneAdvertisementPryanic") & Input.GetKeyDown(KeyCode.E))
        {
            cats.PryanicAdvertisement = true;
           // Text.text = "Esc - закрыть";
           // FulText(true);
            advertisement.gameObject.SetActive(true);
            advertisement.sprite = advertisementSprite[2];
        }

        if (collision.gameObject.CompareTag("ZoneAdvertisementVurdalak") & Input.GetKeyDown(KeyCode.E))
        {
            cats.VurdalakAdvertisement = true;
            // Text.text = "Esc - закрыть";
            // FulText(true);
            advertisement.gameObject.SetActive(true);
            //advertisement.sprite = advertisementSprite[3];
        }

        if (collision.gameObject.CompareTag("ZoneAdvertisementUri") & Input.GetKeyDown(KeyCode.E))
        {
            cats.UriAdvertisement = true;
            // Text.text = "Esc - закрыть";
            // FulText(true);
            advertisement.gameObject.SetActive(true);
           // advertisement.sprite = advertisementSprite[4];
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
