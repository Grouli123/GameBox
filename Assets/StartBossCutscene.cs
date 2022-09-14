using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBossCutscene : MonoBehaviour
{
    public static bool IsCutsceneOn;

    [SerializeField] private Transform _heroPosition;    
    [SerializeField] private Transform _checkpointPosition;


    
    [SerializeField] private float _speed;



    [SerializeField] private Animator _anim;
    [SerializeField] private GameObject _cutsceneText;
    [SerializeField] private PlayerInput playerInput;

    
    [SerializeField] private Animator _animHero;

    private bool _isCutsceneStart = false;
    
    private void Update() 
    {
        if (_isCutsceneStart)
        {
            _heroPosition.position = Vector3.MoveTowards(_heroPosition.position, _checkpointPosition.position, Time.deltaTime * _speed);

            if (_heroPosition.position == _checkpointPosition.position)
            {
                _speed = 0;                
                _animHero.SetBool("IsRun", false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D colision) 
    {
        if(colision.CompareTag("Player"))
        {   //PlayerMovement.speed = 0;

           playerInput.enabled = false;
            IsCutsceneOn = true;
            _anim.SetBool("CutsceneOne", true);
            _cutsceneText.SetActive(true);
            _isCutsceneStart = true;
            _animHero.SetBool("IsRun", true);

            
            
            
            
           // Invoke(nameof(StopCutscene), 3f);
        }
    }

    public void StopCutscene()
    {
        // PlayerMovement.speed = 1;
        playerInput.enabled = true;
        IsCutsceneOn = false;
        // _anim.SetBool("CutsceneOne", false);        
        _cutsceneText.SetActive(false);
        Destroy(gameObject);
    }
}
