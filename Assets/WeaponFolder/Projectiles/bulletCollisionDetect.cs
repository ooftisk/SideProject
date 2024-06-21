using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class bulletCollisionDetect : MonoBehaviour
{
    private int damage; 
    [SerializeField] private GameObject _hitEnemy;
    [SerializeField] private GameObject _hitWall;
    [SerializeField] private float _hitLifetime;
    private GameObject _player;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Walls"))
        {
            Destroy(gameObject);
            GameObject hit = Instantiate(_hitWall, transform.position, Quaternion.identity);
            Destroy(hit, _hitLifetime);
            
        }

        if (other.gameObject.CompareTag("Enemy"))
        { 
            Destroy(gameObject);
            BulletDamage(other.gameObject);
            GameObject hit = Instantiate(_hitEnemy, transform.position, Quaternion.identity);
            Destroy(hit, _hitLifetime);
        }
    }

    public void BulletDamage(GameObject enemy)
    {
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>(); 
        if(enemyHealth != null)
        {
            _player = GameObject.Find("Player");
            damage = _player.GetComponentInChildren<WeaponShoot>().damage;
            enemyHealth.TakeDamage(damage, gameObject);
        }
    }
}
