using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderUp : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private Vector2 _lastPosition;
    [SerializeField] private SliderJoint2D _platform;
    private float speedMove;
    public Vector2 StartPosition;
    
    private void Start()
    {
        _platform = GetComponent<SliderJoint2D>();
        StartPosition = transform.position;        
    }
     
    private void Update()
    {
        JointMotor2D motor = _platform.motor;
        motor.motorSpeed = speedMove;
        _platform.motor = motor;

        if(Vector2.Distance(transform.position, StartPosition) < distance)
        {
            _platform.angle *= -1;
            speedMove = -0.3f;
        }
        else if(Vector2.Distance(transform.position, _lastPosition) < distance)
        {
           _platform.angle *= -1;
            speedMove = 0.3f;
        }
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
