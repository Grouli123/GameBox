using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
  [SerializeField] private GameObject _bullet;  
  [SerializeField] private Transform _firePoint;
  [SerializeField] private DamageDealler _damageDealler;

  [SerializeField] private float _timeBetweenShoots;

    [Header("Sound")]
  [SerializeField] private AudioSource _shootSound; 
  //[SerializeField] private Animator _animator;

  private void Start() 
  {
    _damageDealler = GetComponent<DamageDealler>();
    _shootSound = _shootSound.GetComponent<AudioSource>();    
//    _animator.GetComponent<Animator>();

  }

  public void Shoot(float direction)
  {
      StartCoroutine(CreateCooldown());
     // _animator.SetTrigger("IsAttack");

      _shootSound.Play();
  }

  private IEnumerator CreateCooldown()
  {
    yield return new WaitForSeconds(_timeBetweenShoots);
    GameObject _currentBullet = Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
  }
}