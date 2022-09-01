using Scriptable;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextMoveHelp : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private GameObject _textBackground;
    [SerializeField] private Text Text;

    [Header("Scripts")]
    [SerializeField] private Cats cats;
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private BafHero bafHero;

    [Header("Other")]
    [SerializeField] private Image advertisement;
    [SerializeField] private Sprite[] advertisementSprite; 

    [SerializeField] private IntegerVariable _catsCounter;
    [SerializeField] private int _scoreForPickUpCats;
    private bool _isCatPickUp = false;
    [SerializeField] private float _secondsToDestroy;

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
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ZoneAdvertisementTcepellin"))
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
            
            Test(true);
            
            FulText(true);
            bafHero.onDoubleDamage = true;
        }

        if(collision.gameObject.CompareTag("Cat2") & cats.OfeliyaCat == true)
        {
            Text.text = "Спасибо тебе, внучек!"; 
            
            Test(true);

            FulText(true);
            bafHero.onDoubleSpeed = true;
        }

        if (collision.gameObject.CompareTag("Cat3") & cats.PryanicCat == true)
        {
            Text.text = "Спасибо тебе, внучек!";
            
            Test(true);

            FulText(true);
            bafHero.onDobleLives = true;
        }

        if (collision.gameObject.CompareTag("Tcepellin") & cats.TcepellinAdvertisement == true)
        {
            cats.TcepellinCat = true;
            Text.text = "Кажется, ты нашел первого котика";

            _isCatPickUp = true;

            FulText(true);
            Destroy(collision.gameObject, _secondsToDestroy);
        }

        if (collision.gameObject.CompareTag("Ofeliya") & cats.OfeliyaAdvertisement == true)
        {
            cats.OfeliyaCat = true;
            Text.text = "Кажется, ты нашел второго котика";

            _isCatPickUp = true;

            FulText(true);        
            Destroy(collision.gameObject, _secondsToDestroy);            
        }

        if (collision.gameObject.CompareTag("Pryanic") & cats.PryanicAdvertisement == true)
        {
            cats.PryanicCat = true;
            Text.text = "Кажется, ты нашел третьего котика";

            _isCatPickUp = true;

            FulText(true);
            Destroy(collision.gameObject, _secondsToDestroy);
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
    }

    public void Texting(string text)
    {
        Text.text = text;
    }

    private void FulText(bool active)
    {
        _textBackground.SetActive(active);
    }

    private void Test(bool score)
    {
        if (score == true)
        {
            if(_isCatPickUp == true)
            {
                _catsCounter.ApplyChange(_scoreForPickUpCats);
                _isCatPickUp = false;
                score = false;
            }
        }  
    }

    private IEnumerator ApplayScoreForPickUpCat()
    {
        yield return new WaitForSeconds(_secondsToDestroy);
        _catsCounter.ApplyChange(_scoreForPickUpCats);
    }
}
