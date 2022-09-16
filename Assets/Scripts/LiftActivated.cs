using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftActivated : MonoBehaviour
{
    [SerializeField] private Animator lift;
    //[SerializeField] private Animator leftDoor;
    //[SerializeField] private Animator rightDoor;

    [SerializeField] private BafHero _bafHero;

    public GameObject heroDontMoveInsideLift;

    [SerializeField] private DontMoveHeroLift _heroDontMove;

    [SerializeField] private bool _liftPositionDown;
    private bool _leftDoor = true;
    private bool _rightDoor = false;

   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Up"))
        {
            leftDoor.SetBool("Door", true);
        }
        else
        {
            leftDoor.SetBool("Door", false);
        }

        if (collision.gameObject.CompareTag("Down"))
        {
            rightDoor.SetBool("Door", true);
        }
        else
        {
            rightDoor.SetBool("Door", false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Up"))
        {
            leftDoor.SetBool("Door", true);
        }
        else
        {
            leftDoor.SetBool("Door", false);
        }

        if (collision.gameObject.CompareTag("Down"))
        {
            rightDoor.SetBool("Door", true);
        }
        else
        {
            rightDoor.SetBool("Door", false);
        }
    }
   */

    public void ActivatedLift(string name, bool active)
    {
        lift.SetBool(name, active);
    }

    public bool LiftPositionDown
    {
        get { return _liftPositionDown; }
        set { _liftPositionDown = value; }
    }

    public bool LeftDoor
    {
        get { return _leftDoor; }
        set { _leftDoor = value; }
    }

    public bool RightDoor
    {
        set { _rightDoor = value; }
        get { return _rightDoor; }
    }

    public void StickToTheFloor()
    {
        _heroDontMove.timeDontMoveHero = 19f;
        heroDontMoveInsideLift.SetActive(true);
        _bafHero.heroForceJump = 0;
    }

    public void DetachToTheFloor()
    {
        heroDontMoveInsideLift.SetActive(false);
        _bafHero.heroForceJump = 3.5f;
    }
    public void LiftDown()
    {
        _liftPositionDown = true;
    }

    public void LiftUp()
    {
        _liftPositionDown = false;
    }
}
