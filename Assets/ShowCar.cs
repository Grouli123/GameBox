using System.Collections;
using UnityEngine;

public class ShowCar : MonoBehaviour
{
    [SerializeField] private GameObject _car;
    [SerializeField] private float _time;
    
    void Start()
    {
        _car.SetActive(false);
    }

    void Update()
    {
        _time -= Time.deltaTime;
        if (_time <= 0)
        {
            StartCoroutine(OpenCar());
        }
        else
        {
            StartCoroutine(CloseCar());
        }
    }

    private IEnumerator OpenCar()
    {
        yield return new WaitForSeconds(1);
        _car.SetActive(true);
        _time = 5f;
    }

    private IEnumerator CloseCar()
    {
        yield return new WaitForSeconds(1);
        _car.SetActive(false);
    }
}