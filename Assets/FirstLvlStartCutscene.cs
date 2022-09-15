using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FirstLvlStartCutscene : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private GameObject _James;
    [SerializeField] private GameObject _Shef;
    [SerializeField] private GameObject _cutscene;
    [SerializeField] private GameObject _firstSlide;
    [SerializeField] private GameObject _secondSlide;

    [SerializeField] private ButtonForGame _buttonsForGame;

    [SerializeField] private AudioClip[] _sound;
    [SerializeField] private AudioSource _source;
    
    [SerializeField] private PlayerInput playerInput;

    [SerializeField] private float _textSpeed;

    private string _dialog;
    private void Start() 
    {
        _cutscene.SetActive(true);
        _firstSlide.SetActive(true);
        _secondSlide.SetActive(false);
        _buttonsForGame.enabled = false;
        _source.clip = _sound[0];
        _source.Play();

                
        StartCoroutine(Test());
          
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
        yield return new WaitForSeconds(7);
        _firstSlide.SetActive(false);
        _secondSlide.SetActive(true);
        _James.SetActive(true);
        _Shef.SetActive(false);
        _text.text = "";
        _source.clip = _sound[1];
        _source.Play();
        _dialog = "Добрый вечер, шеф. Вы хотели меня видеть?";
        StartCoroutine(OutputText(_dialog, _textSpeed));

        yield return new WaitForSeconds(5);
        _James.SetActive(false);
        _Shef.SetActive(true);
        _text.text = "";
        _source.clip = _sound[2];
        _source.Play();
        _dialog = "Так точно, мой мальчик. Проходи, садись.";
        StartCoroutine(OutputText(_dialog, _textSpeed));

        yield return new WaitForSeconds(4);
        _James.SetActive(true);
        _Shef.SetActive(false);    
        _text.text = "";
        _source.clip = _sound[3];
        _source.Play();
        _dialog = "Сегодня особенно красивый закат, шеф. В такие вечера мне хочется танцевать под лучами заходящего солнца.";
        StartCoroutine(OutputText(_dialog, _textSpeed));

        
        yield return new WaitForSeconds(8);
        _James.SetActive(false);
        _Shef.SetActive(true);    
        _text.text = "";
        _source.clip = _sound[4];
        _source.Play();
        _dialog = "Да, закат сегодня и вправду волшебный. Мне не хотелось выдергивать тебя в выходной день, но дело требует чрезвычайного  профессионализма, на тебя вся надежда! Тебе известен некто Ритмикс?";
        StartCoroutine(OutputText(_dialog, _textSpeed));

        yield return new WaitForSeconds(15);
        _James.SetActive(true);
        _Shef.SetActive(false);
        _source.clip = _sound[5];
        _source.Play();
        _text.text = "";
        _dialog = "Эм... Диджей клуба Heaven's и популярный исполнитель?";
        StartCoroutine(OutputText(_dialog, _textSpeed));

        yield return new WaitForSeconds(5);
        _James.SetActive(false);
        _Shef.SetActive(true);
        _source.clip = _sound[6];
        _source.Play();
        _text.text = "";
        _dialog = "В точку! Так вот в чем дело: его Фанаты из числа маргиналов начали сбиваться в уличные банды и терроризировать окружающих.";
        StartCoroutine(OutputText(_dialog, _textSpeed));

        yield return new WaitForSeconds(12);
        _James.SetActive(true);
        _Shef.SetActive(false);    
        _text.text = "";
        _source.clip = _sound[7];
        _source.Play();
        _dialog = "Я так понимаю, не насильственным прослушиванием музыки.";
        StartCoroutine(OutputText(_dialog, _textSpeed));

        yield return new WaitForSeconds(5);
        _James.SetActive(false);
        _Shef.SetActive(true);
        _source.clip = _sound[8];
        _source.Play();
        _text.text = "";
        _dialog = "Изначально это был рэкет и мелкие грабежи, но с каждым днём они становятся всё наглее. Мы пытались подослать к ним своих людей, но \"Фанаты\" выводили их из строя быстрее. Поэтому я и решил обратиться к тебе. Выясни, что там происходит, и нейтрализуй угрозу.";
        StartCoroutine(OutputText(_dialog, _textSpeed));

        // yield return new WaitForSeconds(27);
        // _James.SetActive(true);
        // _Shef.SetActive(false);    
        // _text.text = "";
        // _dialog = "Не похоже на уровень \"уличной шпаны\"";
        // StartCoroutine(OutputText(_dialog, _textSpeed));

        // yield return new WaitForSeconds(5);
        // _James.SetActive(false);
        // _Shef.SetActive(true);
        // _text.text = "";
        // _dialog = "Я тоже так подумал. Поэтому и решил обратиться к тебе. Выясни, что там происходит и, по возможности, нейтрилизуй угрозу.";
        // StartCoroutine(OutputText(_dialog, _textSpeed));

        yield return new WaitForSeconds(23);
        _James.SetActive(true);
        _Shef.SetActive(false);    
        _text.text = "";
        _source.clip = _sound[9];
        _source.Play();
        _dialog = "Понял. Я не подведу вас.";
        StartCoroutine(OutputText(_dialog, _textSpeed));
  
        // yield return new WaitForSeconds(7);
        // _James.SetActive(false);
        // _Shef.SetActive(true);
        // _text.text = "";
        // _dialog = "Погоди. Вот еще что. Мы всем отделом спорили, сможешь ли ты справиться с этим делом за N минут. А я никогда в тебе не сомневался, мой мальчик. Если ты уложишься в срок - за мной не заржавеет.";
        // StartCoroutine(OutputText(_dialog, _textSpeed));

        // yield return new WaitForSeconds(28);
        // _James.SetActive(true);
        // _Shef.SetActive(false);    
        // _text.text = "";
        // _dialog = "Выполню всё в лучшем виде, шеф.";
        // StartCoroutine(OutputText(_dialog, _textSpeed));

        yield return new WaitForSeconds(3);
        _James.SetActive(false);
        _Shef.SetActive(false);
        _text.text = "";
        _secondSlide.SetActive(false);
        _cutscene.SetActive(false);
        playerInput.enabled = true;
        _buttonsForGame.enabled = true;
    }
}