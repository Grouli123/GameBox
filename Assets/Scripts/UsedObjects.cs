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

    [Header("Objects")]
    private bool activatedMost = false;
    private bool activatedMost2 = false;
    private bool activatedLift = false;
    private bool _isUpLift = false;

    [SerializeField] private float _timeMoveLift;

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<MostActivated>())
        {
            activatedMost = true;
            textMoveHelp.Texting("Нажмите E");
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
            textMoveHelp.Texting("E - Запуск       R - Двери");
            textMoveHelp.FulText(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<LiftActivated>())
        {
            activatedLift = true;
            textMoveHelp.Texting("E - Запуск    R - Двери");
            textMoveHelp.FulText(true);
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
            liftActivated.LeftDoor == false & liftActivated.RightDoor == false)
        {
            liftActivated.ActivatedLift("Activated", true);
            StartCoroutine(Lift());
        }

        if(Input.GetKeyDown(KeyCode.E) & activatedLift == true & liftActivated.LiftPositionDown == true &
            liftActivated.LeftDoor == false & liftActivated.RightDoor == false)
        {
            liftActivated.ActivatedLift("Activated", false);
            StartCoroutine(Lift());
        }

        if(Input.GetKeyDown(KeyCode.R) & activatedLift == true & liftActivated.LiftPositionDown == false &
            liftActivated.LeftDoor == true & liftActivated.RightDoor == false)
        {
            liftActivated.ActivatedLeftDoor("Door", false);
            liftActivated.LeftDoor = false;
        }
        else if(Input.GetKeyDown(KeyCode.R) & activatedLift == true & liftActivated.LiftPositionDown == false &
            liftActivated.LeftDoor == false & liftActivated.RightDoor == false)
        {
            liftActivated.ActivatedLeftDoor("Door", true);
            liftActivated.LeftDoor = true;
        }

        if(Input.GetKeyDown(KeyCode.R) & activatedLift == true & liftActivated.LiftPositionDown == true &
            liftActivated.LeftDoor == false & liftActivated.RightDoor == false)
        {
            liftActivated.ActivatedRightDoor("Door", true);
            liftActivated.RightDoor = true;
        }
        else if(Input.GetKeyDown(KeyCode.R) & activatedLift == true & liftActivated.LiftPositionDown == true &
            liftActivated.LeftDoor == false & liftActivated.RightDoor == true)
        {
            liftActivated.ActivatedRightDoor("Door", false);
            liftActivated.RightDoor = false;
        }
    }

    private IEnumerator Lift()
    {
        yield return new WaitForSeconds(20);
        if(liftActivated.LiftPositionDown == false)
        {
            liftActivated.LiftPositionDown = true;
        }
        else
        {
            liftActivated.LiftPositionDown = false;
        }
    }
}