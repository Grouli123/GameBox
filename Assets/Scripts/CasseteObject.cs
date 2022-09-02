using UnityEngine;
using Scriptable;

public class CasseteObject : MonoBehaviour
{
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private IntegerVariable _allOfScore;
    [SerializeField] private IntegerVariable _casseteCounter;
    [SerializeField] private int _scoreForPickUpCassete;

    private void Start() 
    {
        _casseteCounter.SetValue(0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerSettings.Cassete += 1;
            _casseteCounter.ApplyChange(_scoreForPickUpCassete);
            _allOfScore.ApplyChange(_scoreForPickUpCassete);
            Destroy(gameObject);
        }
    }
}
