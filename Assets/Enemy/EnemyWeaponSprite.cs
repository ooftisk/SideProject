using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyWeaponSprite : MonoBehaviour
{
    [SerializeField] private Transform _enemy;
    private SpriteRenderer _sprite;
    private bool _canShoot;

    private void Awake()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void Update()
    {
        SpriteRender();
    }

    private void SpriteRender()
    {
        Vector3 playerPosition = PlayerPositionTrack.PlayerPosition;
        Vector3 enemyPosition = _enemy.position;

        
        Vector3 direction = playerPosition - enemyPosition;

        
        float xDifference = Mathf.Abs(direction.x);
        float yDifference = Mathf.Abs(direction.y);

        _canShoot = GetComponentInParent<EnemyAI>().canShoot;
        
        if (_canShoot)
        {
            if (yDifference > xDifference)
            {
                if (direction.y > 0) // »√–Œ  ¬€ÿ≈ œ–Œ“»¬Õ» ¿
                    _sprite.sortingOrder = 1;
                else // Õ»∆≈
                    _sprite.sortingOrder = 3;
            }
            else
            {
                if (direction.x > 0) // »√–Œ  —œ–¿¬¿
                    _sprite.sortingOrder = 3;
                else // —À≈¬¿
                    _sprite.sortingOrder = 3;
            }
        }

    }
}
