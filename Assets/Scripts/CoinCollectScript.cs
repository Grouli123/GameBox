using Scriptable;
using UnityEngine;

public class CoinCollectScript : MonoBehaviour
{
    [SerializeField] private IntegerVariable _coinCounter;
    [SerializeField] private int _scoreForPickUpCoin;
    [SerializeField] private int _scoreForDoublePickUpCoin;

    // [SerializeField] private AudioSource _eatSound;

    private bool doubleCoins = false;

     private void Start() 
    {
        // _eatSound = _eatSound.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (doubleCoins == true)
            {
                _coinCounter.ApplyChange(_scoreForDoublePickUpCoin);
            }
            else
            {
                _coinCounter.ApplyChange(_scoreForPickUpCoin);
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

