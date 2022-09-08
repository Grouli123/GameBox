using UnityEngine;

public class FPSLimit : MonoBehaviour
{
    private void Start() 
    {
        Application.targetFrameRate = 60;    
    }
}