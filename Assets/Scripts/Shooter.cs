using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
  [SerializeField] private GameObject _bullet;  
  [SerializeField] private Transform _firePoint;

[SerializeField] private PlayerInput _playerInput;
  public float timeBetweenShoots;

    [Header("Sound")]
  [SerializeField] private AudioSource _shootSound; 
  //[SerializeField] private Animator _animator;

  private void Start() 
  {
    _shootSound = _shootSound.GetComponent<AudioSource>();    
    _playerInput = GetComponent<PlayerInput>();
//    _animator.GetComponent<Animator>();

  }

  public void Shoot(float direction)
  {
      GameObject _currentBullet = Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
      StartCoroutine(CreateCooldown());
     // _animator.SetTrigger("IsAttack");
      _shootSound.Play();
  }

  private IEnumerator CreateCooldown()
  {
    yield return new WaitForSeconds(timeBetweenShoots);
    _playerInput.bulletOnTheScene = false;
    // GameObject _currentBullet = Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
  }
}