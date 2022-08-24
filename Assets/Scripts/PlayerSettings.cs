using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    [SerializeField] private float lives;
    [SerializeField] private float cassete;
    [SerializeField] private float hairGel;
    [SerializeField] private float james;
    public float Hp
    {
        get { return lives; }
        set { lives = value; }
    }

    public float Cassete
    {
        get { return cassete; }
        set { cassete = value; }
    }

    public float HairGel
    {
        get { return hairGel; }
        set { hairGel = value; }
    }

    public float James
    {
        get { return james; }
        set { james = value; }
    }
}
