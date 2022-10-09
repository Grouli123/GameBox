using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform player;
    public Transform elevatorswitch;
    public Transform downpos;
    public Transform upperpos;

    [SerializeField] private BoxCollider2D _leftDoor;
    [SerializeField] private BoxCollider2D _rightDoor;

    
    [SerializeField] private float _timeToOpenDoor;

    public float speed;

    public bool iselevatordown;

    public bool isLiftRun;

    public float _time;

    private bool _isTimerOn = false;

    private bool _isLiftPositionDown = false;

    void Start()
    {
        isLiftRun = false;

        if (_isTimerOn)
        {
            _time = _timeToOpenDoor;
        }

        _leftDoor.isTrigger = true;                    
        _rightDoor.isTrigger = false;
    }

    void Update()
    {
        StartElevator();

        _time -= Time.deltaTime;

        DistanceToOpen();

        // if (_isLiftPositionDown == true)
        // {
        //     _leftDoor.isTrigger = true;                    
        //     _rightDoor.isTrigger = false;
        // }
        // else
        // {
        //     _leftDoor.isTrigger = false;                    
        //     _rightDoor.isTrigger = true;
        // }
    }

    void DistanceToOpen()
    {
        if(Vector2.Distance(transform.position, downpos.position) < 0.5f)
        {
            _isLiftPositionDown = true;
        }
        else if (Vector2.Distance(transform.position, upperpos.position) < 0.5f)
        {
            _isLiftPositionDown = false;
        }
        
    }

    void StartElevator()
    {
        if (Vector2.Distance(player.position, elevatorswitch.position) < 0.5f && Input.GetKeyDown("e"))
        {

            if (isLiftRun == false)
            {
                if (_isLiftPositionDown == true)
                {
                    _leftDoor.isTrigger = true;                    
                    _rightDoor.isTrigger = false;
                }

                if(transform.position.y <= downpos.position.y)
                {
                    iselevatordown = !iselevatordown;
                    _leftDoor.isTrigger = false;                    
                    _rightDoor.isTrigger = false;
                    isLiftRun = true;
                }
                else if (transform.position.y >= upperpos.position.y)
                {
                    iselevatordown = !iselevatordown;
                    _leftDoor.isTrigger = false;                    
                    _rightDoor.isTrigger = false;
                    isLiftRun = true;
                }
            }
            else if (_isLiftPositionDown == false)
            {
                _leftDoor.isTrigger = false;                    
                _rightDoor.isTrigger = true;
            }   
            else if(_isLiftPositionDown == true)
            {
                _leftDoor.isTrigger = true;                    
                _rightDoor.isTrigger = false;
            }
        }

        if (iselevatordown)
        {
            transform.position = Vector2.MoveTowards(transform.position, upperpos.position, speed * Time.deltaTime);            
        }
        else
        {            
            transform.position = Vector2.MoveTowards(transform.position, downpos.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
            _isTimerOn = true;
            _time = _timeToOpenDoor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
            isLiftRun = false;
        }
    }
}