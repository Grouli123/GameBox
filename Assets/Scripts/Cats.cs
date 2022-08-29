using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cats : MonoBehaviour
{
    private bool _tcepellin = false;
    private bool _ofeliya = false;
    private bool _pryanic = false;

    private bool _tcepellinAdvertisement = false;
    private bool _ofeliyaAdvertisement = false;
    private bool _pryanicAdvertisement = false;

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

    public bool TcepellinAdvertisement
    {
        get { return _tcepellinAdvertisement; }
        set { _tcepellinAdvertisement = value; }
    }

    public bool OfeliyaAdvertisement
    {
        get { return _ofeliyaAdvertisement; }
        set { _ofeliyaAdvertisement = value; }
    }

    public bool PryanicAdvertisement
    {
        get { return _pryanicAdvertisement; }
        set { _pryanicAdvertisement = value; }
    }
}
