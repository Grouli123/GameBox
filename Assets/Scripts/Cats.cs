using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cats : MonoBehaviour
{
    private bool _tcepellin = false;

    public bool TcepellinCat
    {
        get { return _tcepellin; }
        set { _tcepellin = value; }
    } 
}
