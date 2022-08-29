using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BafHero : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private DamageForEnemy damageForEnemy;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private CoinCollectScript coinCollectScript;
    [SerializeField] private PlayerSettings playerSettings;

    private bool OnDoubleDamage = false;
    private bool OnDoubleSpeed = false;
    private bool OnDoubleCoins = false;
    private bool OnDoubleLives = false;
    private bool OnDoubleJump = false;

    private bool DoubleDamage = false;
    private bool DoubleSpeed = false;
    private bool DoubleCoins = false;
    private bool DoubleLives = false;
    private bool DoubleJump = false;

    private void Update()
    {
        Damage();
        Speed();
        Coins();
        Lives();
        Jump();
    }

    private void Damage()
    {

    }

    private void Speed()
    {
        if(DoubleSpeed == true & OnDoubleSpeed == true)
        {
            playerMovement.Speed = 1f;
        }
        else
        {
            playerMovement.Speed = 0.5f;
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

    private void Lives()
    {
        if(DoubleLives == true & playerSettings.Hp >= 10 & OnDoubleLives == true)
        {
            playerSettings.Hp = 15f;
        }
    }

    private void Jump()
    {
        if(DoubleJump == true & OnDoubleJump == true)
        {
            playerMovement.JumpForce = 6f;
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

    public bool doubleLives
    {
        get { return DoubleLives; }
        set { DoubleLives = value; }
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
