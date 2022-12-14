using Scriptable;
using UnityEngine;

public class CoinCollectScript : MonoBehaviour
{
    [SerializeField] private IntegerVariable _coinCounter;
    [SerializeField] private IntegerVariable _allOfScore;
    [SerializeField] private int _scoreForPickUpCoin;
    [SerializeField] private int _countCoin;
    [SerializeField] private int _countDoubleCoin;
    [SerializeField] private int _scoreForDoublePickUpCoin;
    // [SerializeField] private PlayerSettings _playerSettings;

    // [SerializeField] private AudioSource _eatSound;

    private BafHero _bafHero;

    public bool doubleCoins;

     private void Start() 
    {
        // _playerSettings = FindObjectOfType<PlayerSettings>();
        _bafHero = FindObjectOfType<BafHero>();
        _coinCounter.SetValue(0);
        doubleCoins = false;
        // _eatSound = _eatSound.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (_bafHero.coinsDoubleStat == true)
            {
                _coinCounter.ApplyChange(_countDoubleCoin);
                _allOfScore.ApplyChange(_scoreForDoublePickUpCoin);
                //_playerSettings.isAddCassete = false;
            }
            else
            {
                _coinCounter.ApplyChange(_countCoin);
                _allOfScore.ApplyChange(_scoreForPickUpCoin);
                // _playerSettings.isAddCassete = false;
            }
            // _eatSound.Play();
            Destroy(gameObject);
        }
    }

    public bool DoubleCoins
    {
        get { return doubleCoins; }
        set { doubleCoins = value; }
    }
}

