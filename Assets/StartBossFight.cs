using UnityEngine;

public class StartBossFight : MonoBehaviour
{  
    [SerializeField] private BossController _bossController;

    private void Start() 
    {
        _bossController.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            _bossController.enabled = true;
        }        
    }
}
