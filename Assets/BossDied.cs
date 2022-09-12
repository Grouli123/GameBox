using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BossDied : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private GameObject _James;
    [SerializeField] private GameObject _boss;
    [SerializeField] private GameObject _cutscene;
    [SerializeField] private GameObject _firstSlide;

    [SerializeField] private Image _image;
    [SerializeField] private Color _imageColor;

    [SerializeField] private float _textSpeed;

    
    [SerializeField] private GameObject _finishScene;
    [SerializeField] private PlayerInput playerInput;

    [SerializeField] private Animator _anim;

    private string _dialog;




    // private void Start() 
    // {
        
    //     _bossController.enabled = false;
    // }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            _firstSlide.SetActive(true);
            StartCoroutine(Test());
        }        
    }

    private IEnumerator OutputText(string str, float delay)
    {
        foreach (var sym in str)
        {
            _text.text += sym;

            yield return new WaitForSeconds(delay);
        }
    }

    private IEnumerator Test ()
    {   
        playerInput.enabled = false;
        _James.SetActive(false);
        _boss.SetActive(true);
        _text.text = "";
        _dialog = "Ты хорош! Но хорош недостаточно. Плоть никогда не сможет что-то противопоставить крепкости металла.";
        StartCoroutine(OutputText(_dialog, _textSpeed));

        yield return new WaitForSeconds(7);
        _James.SetActive(true);
        _boss.SetActive(false);
        _text.text = "";
        _dialog = "Ты ведь тоже когда-то был человеком...";
        StartCoroutine(OutputText(_dialog, _textSpeed));

        yield return new WaitForSeconds(4);
        _James.SetActive(false);
        _boss.SetActive(true);
        _text.text = "";
        _dialog = "Был! И Я ни о чем не жалею. Эта форма... Это безупречное тело позволило мне сотворить свой опус магнум. Никто и никогда не сравнится со мной в безграничной мощи моего таланта!";
        StartCoroutine(OutputText(_dialog, _textSpeed));

        yield return new WaitForSeconds(15);
        _James.SetActive(true);
        _boss.SetActive(false);
        _text.text = "";
        _dialog = "В скромности тебе не занимать. Это я уже понял.";
        StartCoroutine(OutputText(_dialog, _textSpeed));

        yield return new WaitForSeconds(4);
        _James.SetActive(false);
        _boss.SetActive(true);
        _text.text = "";
        _dialog = "Цыц, ничтожество! Ты спрашивал у меня что здесь происходит, не так ли? Что ж. Ты меня позабавил, полицейский. И я отвечу тебе. То, что ты сейчас услышал - лишь первые аккорды моего нового гениального сигнала. И раз тебе так понравилась вступительная часть, ты обязан задержаться на основную.";
        StartCoroutine(OutputText(_dialog, _textSpeed));

//начать менять цвет.
        yield return new WaitForSeconds(20);
        _anim.SetBool("IsCutsceneOn", true);

        // _imageColor.a = 100;
        // _imageColor.b = 245;
        // _imageColor.r = 255;
        
        _image.color = _imageColor;
        
        _James.SetActive(true);
        _boss.SetActive(false);
        _text.text = "";
        _dialog = "Что происходит?";
        StartCoroutine(OutputText(_dialog, _textSpeed));

        yield return new WaitForSeconds(3);
        _James.SetActive(false);
        _boss.SetActive(true);
        _text.text = "";
        _dialog = "Эта реальность слишком сильно ограничевает мои возможности. Но я собираюсь не просто проникнуть в Киберпространство. Я открою в него двери для всех страждущих.";
        StartCoroutine(OutputText(_dialog, _textSpeed));

        yield return new WaitForSeconds(13);
        _James.SetActive(true);
        _boss.SetActive(false);
        _text.text = "";
        _dialog = "Я остановлю тебя... Любой ценой.";
        StartCoroutine(OutputText(_dialog, _textSpeed));

        yield return new WaitForSeconds(3);
        _James.SetActive(false);
        _boss.SetActive(false);
        _text.text = "";
        _cutscene.SetActive(false);           
        _firstSlide.SetActive(false);
        _finishScene.SetActive(true);
    }
}
