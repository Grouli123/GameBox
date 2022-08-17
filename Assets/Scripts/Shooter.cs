using UnityEngine;

public class Shooter : MonoBehaviour
{
  [SerializeField] private GameObject _bullet;  
  [SerializeField] private Transform _firePoint;

  //[SerializeField] private AudioSource _shootSound; 
  //[SerializeField] private Animator _animator;

  private void Start() 
  {
    //_shootSound = _shootSound.GetComponent<AudioSource>();    
//    _animator.GetComponent<Animator>();
  }

  public void Shoot(float direction)
  {
      GameObject _currentBullet = Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
     // _animator.SetTrigger("IsAttack");

      //_shootSound.Play();
  }
}