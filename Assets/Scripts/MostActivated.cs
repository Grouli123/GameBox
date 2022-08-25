using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostActivated : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void Activated(string name, bool active)
    {
        animator.SetBool(name, active);
    }
}
