using Scriptable;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour
{
    [Header("Sprite")]
    [SerializeField] private Image Gel;
    [SerializeField] private Sprite[] _hairGel;

    [Header("Other")]
    [SerializeField] private float lives;
    [SerializeField] private float cassete;
    [SerializeField] private float hairGel;
    [SerializeField] private Text textCassete;
    [SerializeField] private Animator anim;

    [SerializeField] private IntegerVariable _coins;
    [SerializeField] private IntegerVariable _casseteVar;
    [SerializeField] private int _countCoinsForCassete;

    public bool isAddCassete = false;

    private bool onDoubleLives = false;

    private void Start()
    {
        cassete = 0;
        hairGel = 0;
        anim.SetInteger("Coin", 0);
        _coins.SetValue(0);
    }
    private void Update()
    {
        textCassete.text = cassete.ToString();
        GelUsed();

        if(isAddCassete == false)
        {

            CheckCoinToAddCassete();
        }
        else if (_coins.GetValue() == 0 && _casseteVar.GetValue() == 0)
        {
            cassete = 0;
        }

        // if (_casseteVar.GetValue() > 0)
        // {
        //     cassete =  _casseteVar.GetValue() / 1000f;
        // }
    }

    private void GelUsed()
    {
        switch (hairGel)
        {
            case 0:
                Gel.sprite = _hairGel[0];
                anim.SetInteger("Coin", 0);
                break;
            case 1:
                Gel.sprite = _hairGel[1];
                anim.SetInteger("Coin", 1);
                break;
            case 2:
                Gel.sprite = _hairGel[2];
                anim.SetInteger("Coin", 2);
                break;
            case 3:
                Gel.sprite= _hairGel[3];
                anim.SetInteger("Coin", 3);
                break;
        }
    }

    public float Hp
    {
        get { return lives; }
        set { lives = value; }
    }

    public float Cassete
    {
        get { return cassete; }
        set { cassete = value; }
    }

    public float HairGel
    {
        get { return hairGel; }
        set { hairGel = value; }
    }

    public bool OnDoubleLives
    {
        get { return onDoubleLives; }
        set { onDoubleLives = value; }
    }

    private void CheckCoinToAddCassete()
    {
        //float allOfCoins = _coins.GetValue() / _countCoinsForCassete;

        if (_coins.GetValue() % _countCoinsForCassete == 0)
        {
            //_coins.ApplyChange(_countCoinsForCassete);
            Cassete += 1;
            isAddCassete = true;
        }
    }
}