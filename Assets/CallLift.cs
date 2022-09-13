using UnityEngine;

public class CallLift : MonoBehaviour
{    
    [SerializeField] private Animator lift;
    [SerializeField] private Animator leftDoor;
    [SerializeField] private Animator rightDoor;
    [SerializeField] private TextMoveHelp textMoveHelp;
    
    public void LiftCall(string nameAnim, bool activeAnim)
    {
        lift.SetBool(nameAnim, activeAnim);
    }

    public void LeftDoor(string name, bool active)
    {
        leftDoor.SetBool(name, active);
    }

    public void RightDoor(string name, bool active)
    {
        rightDoor.SetBool(name, active);
    }
}