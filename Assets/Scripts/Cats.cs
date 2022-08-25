using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cats : MonoBehaviour
{
    private bool _tcepellin = false;
    private bool _ofeliya = false;

    public bool TcepellinCat
    {
        get { return _tcepellin; }
        set { _tcepellin = value; }
    } 

    public bool OfeliyaCat
    {
        get { return _ofeliya; }
        set { _ofeliya = value; }
    }
}
