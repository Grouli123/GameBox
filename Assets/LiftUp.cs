using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftUp: MonoBehaviour
{
   //[SerializeField] private GameObject[] waypoints;
   

    [SerializeField] private GameObject _downLiftPosition;

    [SerializeField] private LeftDoorAtcivated _leftDoorActivated;


    private int currentWaypointIndex = 0;
    private bool currentRotation;

    [SerializeField] private float speed = -2f;

    public bool isElevatorUp;


    

    private void Start() 
    {
        currentRotation = false;
        isElevatorUp = false;

    }
    private void Update()
    {
         if (Input.GetKeyDown(KeyCode.E) && _leftDoorActivated.isLiftGoDown == true)
            {
                isElevatorUp = !isElevatorUp;
            }

        if (isElevatorUp == true)
        {
            if (Vector2.Distance(_downLiftPosition.transform.position, transform.position) < .1f)
            {
                currentWaypointIndex++;
                ChangeDirection();

                // if (currentWaypointIndex >= waypoints.Length)
                // {
                //     currentWaypointIndex = 0;
                // }
            }
        
            transform.position = Vector2.MoveTowards(transform.position, _downLiftPosition.transform.position, Time.deltaTime * speed);
        }
    }

  

    private void ChangeDirection()
    {
        currentRotation = !currentRotation;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
