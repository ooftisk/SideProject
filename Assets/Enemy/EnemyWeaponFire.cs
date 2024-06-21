using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponFire : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _enemyProjectile;
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private float _cdTime;
    private bool _canShoot;
    private float _lastShotTime;
    
    

    private void Update()
    {
        EnemyShoot();
    }

    private void EnemyShoot()

    {
        _canShoot = GetComponentInParent<EnemyAI>().canShoot;

        Vector2 directionToPlayer = PlayerPositionTrack.PlayerPosition - _firePoint.position;

        if (_canShoot)
        { 
            if (FireRate())
            {
                GameObject enemyBulletShoot = Instantiate(_enemyProjectile, _firePoint.position, _firePoint.rotation);
                enemyBulletShoot.GetComponent<Rigidbody2D>().AddForce(directionToPlayer.normalized * _projectileSpeed, ForceMode2D.Impulse);

                _lastShotTime = Time.time;
            }
        }
    }

    private bool FireRate()
    {
        return Time.time - _lastShotTime >= _cdTime;
    }
}
