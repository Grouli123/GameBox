using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftActivated : MonoBehaviour
{
    [SerializeField] private Animator lift;
    [SerializeField] private Animator leftDoor;
    [SerializeField] private Animator rightDoor;

    [SerializeField] private BafHero _bafHero;

    public GameObject heroDontMoveInsideLift;

    [SerializeField] private DontMoveHeroLift _heroDontMove;

    private bool _liftPositionDown;
    private bool _leftDoor = true;
    private bool _rightDoor = false;

    public void ActivatedLift(string name, bool active)
    {
        lift.SetBool(name, active);
    }

    public void ActivatedLeftDoor(string name, bool active)
    {
        leftDoor.SetBool(name, active);
    }

    public void ActivatedRightDoor(string name ,bool active)
    {
        rightDoor.SetBool(name, active);
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
}
