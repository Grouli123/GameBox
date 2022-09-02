using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BafHero : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private DamageDealler damageDealler;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private CoinCollectScript coinCollectScript;
    [SerializeField] private PlayerSettings playerSettings;

    [SerializeField] private float _speedMove;

    private bool OnDoubleDamage = false; //1
    private bool OnDoubleSpeed = false; //2
    private bool OnDoubleCoins = false; //4
    private bool OnDoubleLives = false; //5
    private bool OnDoubleJump = false; //3

    private bool DoubleDamage = false;
    private bool DoubleSpeed = false;
    private bool DoubleCoins = false;
    private bool DoubleJump = false;

    private void Start()
    {
        _speedMove = 0.5f;
    }
    private void Update()
    {
        Damage();
        Speed();
        Coins();
        Jump();
    }

    private void Damage()
    {
        if(DoubleDamage == true & OnDoubleDamage == true)
        {
            damageDealler.DoubleDamage = true;
        }
        else
        {
            damageDealler.DoubleDamage = false;
        }
    }
    private void Speed()
    {
        if(DoubleSpeed == true & OnDoubleSpeed == true)
        {
            playerMovement.Speed = _speedMove * 2;
        }
        else
        {
            playerMovement.Speed = _speedMove;
        }
    }

    private void Coins()
    {
        if (DoubleCoins == true & OnDoubleCoins == true)
        {
            coinCollectScript.DoubleCoins = true;
        }
        else
        {
            coinCollectScript.DoubleCoins = false;
        }
    }

    private void Jump()
    {
        if(DoubleJump == true & OnDoubleJump == true)
        {
            playerMovement.JumpForce = 4.5f;
        }
        else
        {
            playerMovement.JumpForce = 3.5f;
        }
    }

    public bool onDoubleDamage
    {
        get { return OnDoubleDamage; }
        set { OnDoubleDamage = value; }
    }

    public bool onDoubleSpeed
    {
        get { return OnDoubleSpeed; }
        set { OnDoubleSpeed = value; }
    }  

    public bool onDobleLives
    {
        get { return OnDoubleLives; }
        set { OnDoubleLives = value; }
    }

    public bool onDoubleCoins
    {
        get { return OnDoubleCoins; }
        set { OnDoubleCoins = value; }
    }

    public bool onDoubleJump
    {
        get { return OnDoubleJump; }
        set { OnDoubleJump = value; }
    }

    public bool doubleDamage
    {
        get { return DoubleDamage; }
        set { DoubleDamage = value; }
    }

    public bool doubleSpeed
    {
        get { return DoubleSpeed; }
        set { DoubleSpeed = value; }
    }

    public bool doubleJump
    {
        get { return DoubleJump; }
        set { DoubleJump = value; }
    }

    public bool doubleCoins
    {
        get { return DoubleCoins; }
        set { DoubleCoins = value; }
    }
}
