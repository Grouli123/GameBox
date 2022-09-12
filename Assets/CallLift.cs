using UnityEngine;

public class CallLift : MonoBehaviour
{    
    [SerializeField] private Animator lift;
    [SerializeField] private TextMoveHelp textMoveHelp;
    
    public void LiftCall(string nameAnim, bool activeAnim)
    {
        lift.SetBool(nameAnim, activeAnim);
    }
}