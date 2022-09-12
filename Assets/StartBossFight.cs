using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartBossFight : MonoBehaviour
{  
    [SerializeField] private Text _text;
    [SerializeField] private GameObject _James;
    [SerializeField] private GameObject _boss;
    [SerializeField] private GameObject _cutscene;
    [SerializeField] private GameObject _firstSlide;

    [SerializeField] private float _textSpeed;

    private string _dialog;





    [SerializeField] private BossController _bossController;

    
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Animator _anim;

    private void Start() 
    {
        _bossController.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            _firstSlide.SetActive(true);
            StartCoroutine(Test());
            _bossController.enabled = true;
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
        _anim.SetBool("IsRun", false);            
        _anim.SetBool("IsJump", false);
        _James.SetActive(true);
        _boss.SetActive(false);
        _text.text = "";
        _dialog = "А вот и виновник торжества. Именем Полиции Неон-Нью-Йорка, что здесь происходит?";
        StartCoroutine(OutputText(_dialog, _textSpeed));

        yield return new WaitForSeconds(6);
        _James.SetActive(false);
        _boss.SetActive(true);
        _text.text = "";
        _dialog = "Так, так, так. Кто у нас здесь? Еще один бестолковый коп? Неужели я не слишком доходчиво дал понять, что вам не стоит совать крысиные носы в мои дела?";
        StartCoroutine(OutputText(_dialog, _textSpeed));

        yield return new WaitForSeconds(12);
        _James.SetActive(true);
        _boss.SetActive(false);
        _text.text = "";
        _dialog = "Руки вверх и отвечайте на вопрос!";
        StartCoroutine(OutputText(_dialog, _textSpeed));

        yield return new WaitForSeconds(4);
        _James.SetActive(false);
        _boss.SetActive(true);
        _text.text = "";
        _dialog = "Повторяю в последний раз, красавчик, уходи по хорошему. Парни, покажите нашему гостю где выход.";
        StartCoroutine(OutputText(_dialog, _textSpeed));

        yield return new WaitForSeconds(7);
        _James.SetActive(true);
        _boss.SetActive(false);
        _text.text = "";
        _dialog = "Твои бандиты тебе не помогут. Я о них уже позаботился.";
        StartCoroutine(OutputText(_dialog, _textSpeed));

        yield return new WaitForSeconds(6);
        _James.SetActive(false);
        _boss.SetActive(true);
        _text.text = "";
        _dialog = "Проклятье! Всё приходится делать самому. Что ж, тебе повезло. Ты первым ощутишь на себе всю гениальность тизера моего нового альбома.";
        StartCoroutine(OutputText(_dialog, _textSpeed));

        yield return new WaitForSeconds(10);
        _James.SetActive(false);
        _boss.SetActive(false);
        _text.text = "";
        _cutscene.SetActive(false);           
        _firstSlide.SetActive(false);        
        playerInput.enabled = true;
    }
}