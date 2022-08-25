using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsedObjects : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private PlayerSettings settings;
    [SerializeField] private MostActivated mostActivated;
    [SerializeField] private LiftActivated liftActivated;
    [SerializeField] private TextMoveHelp textMoveHelp;

    [Header("Text")]
    [SerializeField] private Text CasseteText;
    [SerializeField] private Text JamesText;
    [SerializeField] private Text GelText;

    [Header("Objects")]
    [SerializeField] private GameObject DoorLift;
    private bool activatedMost = false;
    private bool activatedLift = false;
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

        if (collision.gameObject.GetComponent<MostActivated>())
        {
            activatedMost = true;
            textMoveHelp.Texting("ֽאזלטעו E");
        }

        if (collision.gameObject.GetComponent<LiftActivated>())
        {
            activatedLift = true;
            textMoveHelp.Texting("ֽאזלטעו E");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E) & activatedMost == true)
        {
            mostActivated.Activated("Most", true);
        }

        if(Input.GetKey(KeyCode.E) & activatedLift == true)
        {
            liftActivated.Activated("Activated", true);
            Destroy(DoorLift, 10);
        }
    }

}
