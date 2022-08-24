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

    private void Start()
    {
        weap1.sprite = active;
        weap2.sprite = notActive;
        weap3.sprite = notActive;
        weap4.sprite = notActive;
    }

    private void Update()
    {
        ClickNumberWeapons();
    }

    private void ClickNumberWeapons()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weap1.sprite = active;
            weap2.sprite = notActive;
            weap3.sprite = notActive;
            weap4.sprite = notActive;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weap1.sprite = notActive;
            weap2.sprite = active;
            weap3.sprite = notActive;
            weap4.sprite = notActive;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weap1.sprite = notActive;
            weap2.sprite = notActive;
            weap3.sprite = active;
            weap4.sprite = notActive;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            weap1.sprite = notActive;
            weap2.sprite = notActive;
            weap3.sprite = notActive;
            weap4.sprite = active;
        }
    }
}
