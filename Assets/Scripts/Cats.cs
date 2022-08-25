using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cats : MonoBehaviour
{
    private bool _tcepellin = false;
    private bool _ofeliya = false;
    private bool _pryanic = false;

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

    public bool PryanicCat
    {
        get { return _pryanic; }
        set { _pryanic = value; }
    }
}
