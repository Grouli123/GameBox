using UnityEngine;

public class FinishLvl : MonoBehaviour
{
    [SerializeField] private GameObject _finishScene;
    [SerializeField] private PlayerMovement _playerMovement;

    private void Start() 
    {
        _finishScene.SetActive(false);   
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("FinishLevel"))
        {
            _playerMovement.Speed = 0f;
            _finishScene.SetActive(true);
        }
    }
}
