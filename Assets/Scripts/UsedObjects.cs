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
    [SerializeField] private BoxCollider2D _rightDoorLift;
    [SerializeField] private BoxCollider2D _leftDoorLift;
    private bool activatedMost = false;
    private bool activatedMost2 = false;
    private bool activatedLift = false;
    private bool _isUpLift = false;

    [SerializeField] private float _timeMoveLift;

// Сделать тригер левой двери и тригер правой.
// Когда герой входит в первую дверь и нажимает Е
// дверь закрывается и лифт едет вниз. Внизу открывается вторая дверь.
// Когда герой входит во вторую дверь и нажимает Е
// вторая дверь закрывается и лифт поднимается наверх.
// Наверху первая дверь открывается

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
            textMoveHelp.Texting("Нажмите E");
            textMoveHelp.FulText(true);
        }

        if (collision.CompareTag("leftLiftDoor"))
        {
            activatedLift = true;
        }

        if (collision.CompareTag("rightLiftDoor"))
        {
            _isUpLift = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E) & activatedMost == true)
        {
            mostActivated.Activated("Most", true);
        }

        if (Input.GetKey(KeyCode.E) & activatedMost2 == true)
        {
            mostActivated2.Animation("Activation", true);
        }

        if (Input.GetKey(KeyCode.E) & activatedLift == true)
        {
            liftActivated.Activated("Activated", true);            
            _leftDoorLift.isTrigger = false;
            _rightDoorLift.isTrigger = false;

            Debug.Log("едем вниз");
            StartCoroutine(WaitForRightDoorOpen());
            //Destroy(DoorLift, 10);
        }

        if(Input.GetKey(KeyCode.E) & _isUpLift == true)
        {
            liftActivated.Activated("IsUp", true);            
            _leftDoorLift.isTrigger = false;
            _rightDoorLift.isTrigger = false;
            
            Debug.Log("едем вверх");
            StartCoroutine(WaitForLeftDoorOpen());
        }
    }

    private IEnumerator WaitForRightDoorOpen()
    {
        yield return new WaitForSeconds(_timeMoveLift);
        _rightDoorLift.isTrigger = true;
        _leftDoorLift.isTrigger = false;
        activatedLift = false;
        liftActivated.Activated("Activated", false);            

    }

    private IEnumerator WaitForLeftDoorOpen()
    {
        yield return new WaitForSeconds(_timeMoveLift);
        _rightDoorLift.isTrigger = false;
        _leftDoorLift.isTrigger = true;
        _isUpLift = false;
        liftActivated.Activated("IsUp", false);            
    }
}