using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontMoveHeroLift : MonoBehaviour
{
    [SerializeField] private LiftActivated _liftActivated;

    public float timeDontMoveHero;

    private void Update() {

        timeDontMoveHero -= Time.deltaTime;
    }
   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionStay2D(Collision2D collision) 
    {
        if (timeDontMoveHero <= 0)
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}