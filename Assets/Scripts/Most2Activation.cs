using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Most2Activation : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Animator anim2;

    public void Animation(string name, bool active)
    {
        anim.SetBool(name, active);
        anim2.SetBool(name, active);
    }
}
