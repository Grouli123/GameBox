using Scriptable;
using UnityEngine;

public class CoinCollectScript : MonoBehaviour
{
    [SerializeField] private IntegerVariable _coinCounter;    
    // [SerializeField] private AudioSource _eatSound;

     private void Start() 
    {
        // _eatSound = _eatSound.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Damageable"))
        {
            _coinCounter.ApplyChange(1);
            // _eatSound.Play();
            Destroy(gameObject);
        }
    }
}

