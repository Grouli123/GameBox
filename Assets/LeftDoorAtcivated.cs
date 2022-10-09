using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftDoorAtcivated : MonoBehaviour
{
   public bool isLiftGoDown;

    private void Start() 
    {
        isLiftGoDown = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
           isLiftGoDown = true;

        }
    }
}