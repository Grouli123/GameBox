using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsedObjects : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private PlayerSettings settings;

    [Header("Text")]
    [SerializeField] private Text CasseteText;
    [SerializeField] private Text JamesText;
    [SerializeField] private Text GelText;

    private void Update()
    {
        CasseteText.text = settings.Cassete.ToString();
        JamesText.text = settings.James.ToString();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CasseteHP"))
        {
            settings.Cassete += 1;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("James"))
        {
            settings.James += 1;
            Destroy(collision.gameObject);
        }

       // if (collision.gameObject.CompareTag("HairGel"))
        //{
          //  settings.HairGel += 1;
          //  Destroy(collision.gameObject);
       // }
    }

}
