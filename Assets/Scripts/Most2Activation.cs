using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Most2Activation : MonoBehaviour
{
    [SerializeField] Animator anim;

    public void Animation(string name, bool active)
    {
        anim.SetBool(name, active);
    }
}
