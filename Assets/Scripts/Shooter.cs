using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
  [SerializeField] private GameObject _bullet;  
  [SerializeField] private Transform _firePoint;

  [SerializeField] private PlayerInput _playerInput;
  public float timeBetweenShoots;

    [Header("Sound")]
  public AudioSource shootSound; 
  //[SerializeField] private Animator _animator;

  private void Start() 
  {
    shootSound = shootSound.GetComponent<AudioSource>();    
    _playerInput = GetComponent<PlayerInput>();
//    _animator.GetComponent<Animator>();

  }

  public void Shoot(float direction)
  {
      GameObject _currentBullet = Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
      StartCoroutine(CreateCooldown());
     // _animator.SetTrigger("IsAttack");
      shootSound.Play();
  }

  private IEnumerator CreateCooldown()
  {
    yield return new WaitForSeconds(timeBetweenShoots);
    _playerInput.bulletOnTheScene = false;
    // GameObject _currentBullet = Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
  }
}