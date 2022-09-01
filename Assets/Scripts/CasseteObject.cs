using UnityEngine;
using Scriptable;

public class CasseteObject : MonoBehaviour
{
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private IntegerVariable _coinCounter;
    [SerializeField] private int _scoreForPickUpCassete;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerSettings.Cassete += 1;
            _coinCounter.ApplyChange(_scoreForPickUpCassete);
            Destroy(gameObject);
        }
    }
}
