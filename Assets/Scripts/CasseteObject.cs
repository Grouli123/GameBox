using UnityEngine;

public class CasseteObject : MonoBehaviour
{
    [SerializeField] private PlayerSettings playerSettings;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerSettings.Cassete += 1;
            Destroy(gameObject);
        }
    }
}
