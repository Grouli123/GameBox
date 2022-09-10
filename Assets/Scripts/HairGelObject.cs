using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairGelObject : MonoBehaviour
{
    [SerializeField] private PlayerSettings playerSettings;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && playerSettings.HairGel < 3)
        {
            playerSettings.HairGel += 1;
            Destroy(gameObject);
        }
    }
}
