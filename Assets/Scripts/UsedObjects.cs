using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsedObjects : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private PlayerSettings settings;
    [SerializeField] private MostActivated mostActivated;
    [SerializeField] private Most2Activation mostActivated2;
    [SerializeField] private LiftActivated liftActivated;
    [SerializeField] private TextMoveHelp textMoveHelp;

    [SerializeField] private CallLift _callLift;

    [Header("Objects")]
    private bool activatedMost = false;
    private bool activatedMost2 = false;
    private bool activatedLift = false;

    private bool _isLiftUp = false;

    private float horizontal;

    [Header("Sounds")]
    [SerializeField] private AudioSource box;
    [SerializeField] private AudioSource artefactSound;
    [SerializeField] private AudioSource coinSound;
    [SerializeField] private AudioSource grandMatherSound;
    [SerializeField] private AudioSource runStone;
    [SerializeField] private AudioSource runMetall;
 
    [SerializeField] private float _timeMoveLift;


    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Cat1") | collision.gameObject.CompareTag("Cat2") | collision.gameObject.CompareTag("Cat3")
            | collision.gameObject.CompareTag("Cat4") | collision.gameObject.CompareTag("Cat5"))
        {
            grandMatherSound.Play();
        }

        if (collision.gameObject.GetComponent<CoinCollectScript>())
        {
            coinSound.Play();
        }

        if (collision.gameObject.GetComponent<HairGelObject>() | collision.gameObject.GetComponent<CasseteObject>())
        {
            artefactSound.Play();
        }

        if (collision.gameObject.GetComponent<MostActivated>())
        {
            activatedMost = true;
            textMoveHelp.Texting("E - Активировать мост");
            textMoveHelp.FulText(true);
        }

        if (collision.gameObject.GetComponent<Most2Activation>())
        {
            activatedMost2 = true;
            textMoveHelp.Texting("E - Активировать мост");
            textMoveHelp.FulText(true);
        }

        if (collision.gameObject.GetComponent<LiftActivated>())
        {
            activatedLift = true;
            textMoveHelp.Texting("E - Запуск");
            textMoveHelp.FulText(true);
        }
        else
        {
            activatedLift = false;
        }

        if (collision.gameObject.GetComponent<CallLift>())
        {
            _isLiftUp = true;
            textMoveHelp.Texting("E - Вызов лифта");
            textMoveHelp.FulText(true);
        }
        else
        {
            _isLiftUp = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<LiftActivated>())
        {
            activatedLift = true;
            textMoveHelp.Texting("E - Запуск");
            textMoveHelp.FulText(true);
        }
        else
        {
            activatedLift = false;
        }

        if (Input.GetKeyDown(KeyCode.E) & activatedMost == true)
        {
            mostActivated.Activated("Most", true);
        }

        if (Input.GetKeyDown(KeyCode.E) & activatedMost2 == true)
        {
            mostActivated2.Animation("Activation", true);
        }

        if (Input.GetKeyDown(KeyCode.E) & activatedLift == true & liftActivated.LiftPositionDown == false & 
            liftActivated.LeftDoor == true & liftActivated.RightDoor == false)
        {
            liftActivated.ActivatedRightDoor("Door", false);
            liftActivated.ActivatedLeftDoor("Door", false);
            liftActivated.ActivatedLift("Activated", true);
            StartCoroutine(Lift());
        }

        if(Input.GetKeyDown(KeyCode.E) & activatedLift == true & liftActivated.LiftPositionDown == true &
            liftActivated.LeftDoor == false & liftActivated.RightDoor == true)
        {
            liftActivated.ActivatedRightDoor("Door", false);
            liftActivated.ActivatedLeftDoor("Door", false);
            liftActivated.ActivatedLift("Activated", false);
            StartCoroutine(Lift());
        }

        if(Input.GetKeyDown(KeyCode.E) 
            & _isLiftUp == true & liftActivated.LiftPositionDown == true)
        {
            liftActivated.LeftDoor = false;
            liftActivated.RightDoor = false;
            _callLift.LeftDoor("Door", false);
            _callLift.RightDoor("Door", false);
            StartCoroutine(LiftUp());
            StartCoroutine(Lift());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(horizontal > 0.1 & collision.gameObject.CompareTag("Ground") || horizontal < -0.1 & collision.gameObject.CompareTag("Ground"))
        {
           // runStone.Play();
        }
        else if(horizontal == 0)
        {
           // runStone.Stop();
        }

        if(horizontal > 0.1 & collision.gameObject.CompareTag("Metall") || horizontal < -0.1 & collision.gameObject.CompareTag("Metall"))
        {
           // runMetall.Play();
        }
        else if (horizontal == 0)
        {
           // runMetall.Stop();
        }

        if (collision.gameObject.CompareTag("Box"))
        {
           // box.Play();
        }
        else
        {
           // box.Stop();
        }
    }

    private IEnumerator LiftUp()
    {
        yield return new WaitForSeconds(2);
        liftActivated.ActivatedLift("Activated", false);
    }


    private IEnumerator Lift()
    {
        yield return new WaitForSeconds(20);
        liftActivated.LiftPositionDown = !liftActivated.LiftPositionDown;

        yield return new WaitForSeconds(1);
        if (liftActivated.LiftPositionDown == false)
        {
            liftActivated.ActivatedRightDoor("Door", false);
            liftActivated.ActivatedLeftDoor("Door", true);
            liftActivated.LeftDoor = true;
            liftActivated.RightDoor = false;
        }
        else
        {
            liftActivated.ActivatedRightDoor("Door", true);
            liftActivated.ActivatedLeftDoor("Door", false);
            liftActivated.LeftDoor = false;
            liftActivated.RightDoor = true;
        }
    }
}