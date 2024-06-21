using UnityEngine.InputSystem;   
using UnityEngine;
using Unity.VisualScripting;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private Transform pivotTransform;
    [SerializeField] private GameObject _weapon;
    [SerializeField] private SpriteRenderer playerRender;
    [SerializeField] private Transform _defaultPosition;
    [SerializeField] private Transform _topPosition;
    [SerializeField] private Transform _bottomPosition;
    [SerializeField] private Transform _leftPosition;
    [SerializeField] private Transform _rightPosition;
    private SpriteRenderer _weaponGFX;



    private void Awake()
    {
        _weaponGFX = pivotTransform.GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        WeaponSetPosition();
    }


    private void WeaponSetPosition()
    {
        if (playerInput.rightStick.magnitude == 0f)
        {
            Vector3 moveDirection = playerInput.leftStick.normalized;

            float moveDirectionX = Mathf.Abs(moveDirection.x);
            float moveDirectionY = Mathf.Abs(moveDirection.y);

            _weapon.transform.localScale = new Vector3(1f, 1f, 1f);

            if (moveDirectionY > moveDirectionX)
            {
                if (moveDirection.y > 0.1f) // Õ¿¬≈–’
                {
                    _weapon.transform.position = _topPosition.position;
                    _weapon.transform.rotation = _topPosition.rotation;
                    _weaponGFX.sortingOrder = playerRender.sortingOrder - 1;
                    _weaponGFX.flipY = true;
                    _weaponGFX.flipX = false;
                }
                else // ¬Õ»«
                {
                    _weapon.transform.position = _bottomPosition.position;
                    _weapon.transform.rotation = _bottomPosition.rotation;
                    _weaponGFX.flipX = false;
                    _weaponGFX.flipY = false;
                    _weaponGFX.sortingOrder = playerRender.sortingOrder + 1;
                }
            }
            else if (moveDirectionY < moveDirectionX)
            {
                if (moveDirection.x > 0.1f) // Õ¿œ–¿¬Œ
                {
                    _weapon.transform.position = _rightPosition.position;
                    _weapon.transform.rotation = _rightPosition.rotation;
                    _weaponGFX.flipX = false;
                    _weaponGFX.flipY = false;
                    _weaponGFX.sortingOrder = playerRender.sortingOrder + 1;
                }
                else if (moveDirection.x < -0.1f) // ¬À≈¬Œ
                {
                    _weapon.transform.position = _leftPosition.position;
                    _weapon.transform.rotation = _leftPosition.rotation;
                    _weaponGFX.flipX = true;
                    _weaponGFX.flipY = false;
                    _weaponGFX.sortingOrder = playerRender.sortingOrder + 1;
                }
            }
            else
            {
                _weapon.transform.position = _defaultPosition.position;
                _weapon.transform.rotation = _defaultPosition.rotation;
                _weaponGFX.sortingOrder = playerRender.sortingOrder + 1;
                _weaponGFX.flipX = false;
                _weaponGFX.flipY = false;
            }
        }
        else
        {
            _weapon.transform.rotation = pivotTransform.rotation;
        }
    }
} 

