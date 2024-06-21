using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotScript : MonoBehaviour
{
    private SpriteRenderer _weaponGFX;
    [SerializeField] private Transform _weapon;
    [SerializeField] private SpriteRenderer _playerRender;

    private void Awake()
    {
        _weaponGFX = GetComponentInChildren<SpriteRenderer>();
    }
    void Update()
    {
        
        Vector3 rStickPos = playerInput.rightStick;

        _weaponGFX.flipX = false;
        _weaponGFX.flipY = false;

        Vector2 direction = transform.position + new Vector3(rStickPos.x, rStickPos.y).normalized * 0.5f;
        _weapon.transform.position = direction;

        float rotationAngle = Mathf.Atan2(rStickPos.y, rStickPos.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);

        Vector2 scale = _weapon.transform.localScale;

        if (rStickPos.x < 0)
        {
            scale.y = -1;
        }
        else if (rStickPos.x > 0)
        {
            scale.y = 1;
        }

        _weapon.transform.localScale = scale;


        if (_weapon.transform.eulerAngles.z > 45 && _weapon.transform.eulerAngles.z < 135)
        {
            _weaponGFX.sortingOrder = _playerRender.sortingOrder - 1;
        }
        else
        {
            _weaponGFX.sortingOrder = _playerRender.sortingOrder + 1;
        }
        
    }
        
}
