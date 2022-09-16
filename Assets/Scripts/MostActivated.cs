using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostActivated : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Animator _animLever;

    public void Activated(string name, bool active)
    {
        animator.SetBool(name, active);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() & Input.GetKeyDown(KeyCode.E))
        {
            _animLever.SetBool("Open", true);
        }
    }
}
