using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Most2Activation : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Animator anim2;
    [SerializeField] private TextMoveHelp textMoveHelp;

    public void Animation(string name, bool active)
    {
        textMoveHelp.MostOpen = false;
        anim.SetBool(name, active);
        anim2.SetBool(name, active);
    }
}
