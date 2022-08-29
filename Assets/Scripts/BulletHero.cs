
using UnityEngine;

public class BulletHero : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private DamageForEnemy damageForEnemy;
    [SerializeField] private BafHero bafHero;

    private void Start()
    {
        damageForEnemy = GetComponent<DamageForEnemy>();
        bafHero = GetComponent<BafHero>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(bafHero.doubleDamage == true & bafHero.onDoubleDamage == true)
        {
            collision.gameObject.GetComponent<DamageForEnemy>().DoubleDamage = true;
        }
        else
        {
            collision.gameObject.GetComponent<DamageForEnemy>().DoubleDamage = false;
        }
    }
}
