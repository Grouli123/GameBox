using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallLiftUp : MonoBehaviour
{
    [SerializeField] private Elevator _elevator;
    [SerializeField] private TextMoveHelp textMoveHelp;
    
    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _elevator.transform.position = Vector2.MoveTowards(_elevator.transform.position, _elevator.downpos.position, _elevator.speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.GetComponent<UsedObjects>())
        {
            textMoveHelp.Texting("E - Вызов лифта");
        }
    }
}
