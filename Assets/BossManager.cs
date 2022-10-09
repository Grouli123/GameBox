using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _groundBoss;  
    [SerializeField] private SliderJoint2D[] _sliderJooint;
    [SerializeField] private SliderUp[] _sliderUp;

    [SerializeField] private DamageForBoss _damageForBoss;

    [SerializeField] private BossController _bossController;
    [SerializeField] private BossControllerTwo _bossControllerTwo;
    [SerializeField] private BossBulletThree _bossBulletThree;

    [SerializeField] private Animator _anim;


    private void Start() 
    {
        _anim = GetComponent<Animator>();
        _bossBulletThree.enabled = false;

        // _bossController.enabled = true;
        // _bossControllerTwo.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (_bossController.enabled == true)
        {
            _anim.SetBool("IsLeft", true);
        }
        else
        {            
            _anim.SetBool("IsLeft", false);
        }

        if (_bossControllerTwo.enabled == true)
        {
            _anim.SetBool("IsRight", true);
        }
        else
        {            
            _anim.SetBool("IsRight", false);
        }

        if (_bossBulletThree.enabled == true)
        {
            _anim.SetBool("IsUp", true);
        }
        else
        {            
            _anim.SetBool("IsUp", false);
        }

        if (_damageForBoss.lives <= 25)
        {
            SecondState();
 
        }

        if (_damageForBoss.lives <= 15)
        {
            ThirdState();
        }
    }

    private void SecondState()
    {
        _bossController.enabled = true;
        _bossControllerTwo.enabled = true;
        _bossBulletThree.enabled = true;
        
        for (int i = 0; i < _groundBoss.Length; i++)
        {
            _groundBoss[i].SetActive(false);
        }
    }

    private void ThirdState()
    {
        _bossController.enabled = true;
        _bossControllerTwo.enabled = true;
        _bossBulletThree.enabled = true;
        for (int i = 0; i < _sliderJooint.Length; i++)
        {
            _sliderJooint[i].enabled = true;
        }

        for (int i = 0; i < _sliderUp.Length; i++)
        {
            _sliderUp[i].enabled = true;
        }
    }
}
