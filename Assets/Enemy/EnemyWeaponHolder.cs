using UnityEngine;
using UnityEngine.AI;

public class EnemyWeaponHolder : MonoBehaviour
{
    private NavMeshAgent _agent;
    [SerializeField] private Transform _pivot;
    [SerializeField] private Transform _weaponHolder; // ÚÓÎ¸ÍÓ ‚ PositionAdjust
    [SerializeField] private Transform _enemyWeapon; // ÚÓÎ¸ÍÓ ‚ PositionAdjust
    [SerializeField] private Transform _defaultPosition;

    [SerializeField] private Transform _top;
    [SerializeField] private Transform _bottom;
    [SerializeField] private Transform _left;
    [SerializeField] private Transform _right;

    [SerializeField] private LayerMask _wallLayer;
    private SpriteRenderer _sprite;

    [SerializeField] private float _smoothnessFactor;
    private Vector3 _smoothedMoveDirection;

    private bool _canShoot;


    private void Awake()
    {
        _agent = GetComponentInParent<NavMeshAgent>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        WeaponRotation();
    }

    private void WeaponRotation()
    {
        _canShoot = GetComponentInParent<EnemyAI>().canShoot;
        
        if (_canShoot)
        {
            _sprite.flipX = false;
            _sprite.flipY = false;
            _enemyWeapon.localScale = _weaponHolder.localScale;
            _enemyWeapon.position = _weaponHolder.position;
            _enemyWeapon.rotation = _weaponHolder.rotation;

            float directionToPlayerX = PlayerPositionTrack.PlayerPosition.x - transform.position.x;
            float directionToPlayerY = PlayerPositionTrack.PlayerPosition.y - transform.position.y;
            float rotationAngle = Mathf.Atan2(directionToPlayerY, directionToPlayerX) * Mathf.Rad2Deg;


            Vector2 weaponScale = _pivot.transform.localScale;

            float normalizedRotation = Mathf.Repeat(_pivot.transform.eulerAngles.z + 180f, 360f) - 180f;

            _pivot.transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);

            if (normalizedRotation > 90f || normalizedRotation < -90f)
            {
                weaponScale.y = -1;
            }
            else
            {
                weaponScale.y = 1;
            }
            _pivot.transform.localScale = weaponScale;
        }
        else
        {
            PositionAdjust();
        }
    }



    // ‘» —¿Õ”“‹ “”“!!!!!!!!

    private void PositionAdjust()
    {
        Vector3 moveDirection = _agent.velocity.normalized;

        _smoothedMoveDirection = Vector3.Lerp(_smoothedMoveDirection, moveDirection, Time.deltaTime * _smoothnessFactor);

        float moveDirectionX = Mathf.Abs(_smoothedMoveDirection.x);
        float moveDirectionY = Mathf.Abs(_smoothedMoveDirection.y);

        if (moveDirectionY > moveDirectionX)
        {
            if (_smoothedMoveDirection.y > 0) // »√–Œ  ¬€ÿ≈ œ–Œ“»¬Õ» ¿
            {
                _enemyWeapon.position = _top.position;
                _enemyWeapon.rotation = _top.rotation;
                _enemyWeapon.localScale = _top.localScale;
                _sprite.flipX = false;
                _sprite.sortingOrder = 1;
            }
            else // Õ»∆≈
            {
                _enemyWeapon.position = _bottom.position;
                _enemyWeapon.rotation = _bottom.rotation;
                _enemyWeapon.localScale = _bottom.localScale;
                _sprite.flipX = false;
                _sprite.sortingOrder = 3;
            }
        }
        else if (moveDirectionY < moveDirectionX)
        {
            if (_smoothedMoveDirection.x > 0) // »√–Œ  —œ–¿¬¿
            {
                _enemyWeapon.position = _right.position;
                _enemyWeapon.rotation = _right.rotation;
                _enemyWeapon.localScale = _right.localScale;
                _sprite.flipX = false;
                _sprite.sortingOrder = 3;
            }
            else // —À≈¬¿
            {
                _enemyWeapon.position = _left.position;
                _enemyWeapon.rotation = _left.rotation;
                _enemyWeapon.localScale = _left.localScale;
                _sprite.flipX = true;
                _sprite.sortingOrder = 3;
            }
        }
        else
        {
            _enemyWeapon.position = _defaultPosition.position;
            _enemyWeapon.localScale = _defaultPosition.localScale;
            _sprite.flipX = false;
            _sprite.sortingOrder = 3;
        }
    }
}
