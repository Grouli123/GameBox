using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour
{
    [SerializeField] private float lives;
    [SerializeField] private float cassete;
    [SerializeField] private Text textCassete;

    private void Update()
    {
        textCassete.text = cassete.ToString();
    }
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
}
