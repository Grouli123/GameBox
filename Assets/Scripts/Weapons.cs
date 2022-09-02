using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapons : MonoBehaviour
{
    [Header("ImageCanvas")]
    [SerializeField] private Sprite notActive;
    [SerializeField] private Sprite active;
    [SerializeField] private Image weap1;
    [SerializeField] private Image weap2;
    [SerializeField] private Image weap3;
    [SerializeField] private Image weap4;
    [SerializeField] private Image weap5;

    [Header("Scripts")]
    [SerializeField] private BafHero bafHero;

    private void Start()
    {
        weap1.sprite = notActive;
        weap2.sprite = notActive;
        weap3.sprite = notActive;
        weap4.sprite = notActive;
        weap5.sprite = notActive;
    }

    private void Update()
    {
        ClickNumberWeapons();
    }

    private void ClickNumberWeapons()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) & bafHero.onDoubleDamage == true)
        {
            bafHero.doubleDamage = true;
            bafHero.doubleSpeed = false;
            bafHero.doubleJump = false;
            bafHero.doubleCoins = false;
            weap1.sprite = active;
            weap2.sprite = notActive;
            weap3.sprite = notActive;
            weap4.sprite = notActive;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) & bafHero.onDoubleSpeed == true)
        {
            bafHero.doubleDamage = false;
            bafHero.doubleSpeed = true;
            bafHero.doubleJump = false;
            bafHero.doubleCoins = false;
            weap1.sprite = notActive;
            weap2.sprite = active;
            weap3.sprite = notActive;
            weap4.sprite = notActive;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) & bafHero.onDoubleJump == true)
        {
            bafHero.doubleDamage = false;
            bafHero.doubleSpeed = false;
            bafHero.doubleJump = true;
            bafHero.doubleCoins = false;
            weap1.sprite = notActive;
            weap2.sprite = notActive;
            weap3.sprite = active;
            weap4.sprite = notActive;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) & bafHero.onDoubleCoins == true)
        {
            bafHero.doubleDamage = false;
            bafHero.doubleSpeed = false;
            bafHero.doubleJump = false;
            bafHero.doubleCoins = true;
            weap1.sprite = notActive;
            weap2.sprite = notActive;
            weap3.sprite = notActive;
            weap4.sprite = active;
        }
        else if (bafHero.onDobleLives == true)
        {
            weap5.sprite = active;
        }
    }
}
