using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCheck : MonoBehaviour
{
    [SerializeField] private PlayerSettings _playerSettings;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private float _fallingDistanseToDamage;
    // [SerializeField] private float _midleFallingDistanseToDamage;

    private void Start() 
    {
        _playerMovement.GetComponent<PlayerMovement>();
        _playerSettings.GetComponent<PlayerSettings>();
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            Debug.Log(_playerMovement.rb.velocity.y);
        }

        if (collision.gameObject.tag.Equals("Ground") && _playerMovement.rb.velocity.y < _fallingDistanseToDamage)
        {
            Debug.Log("Damage");
            _playerSettings.Hp -= 2;
        }

        // if (collision.gameObject.tag.Equals("Ground") && _playerMovement.rb.velocity.y < _midleFallingDistanseToDamage)
        // {
        //     Debug.Log("MidleDamage");
        //     _playerSettings.Hp -= 5;
        // }
    }
}
