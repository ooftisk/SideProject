using System.Collections;
using UnityEngine;


public class playerMechanics : MonoBehaviour
{
    private Rigidbody2D _rb;

    [Header("Движение")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private bool _canMove;

    [Header("Дэш")]
    [SerializeField] private float _startDashTime;
    private float _currentDashTime;
    [SerializeField] private float _dashSpeed;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _canMove = true;
    }


    private void FixedUpdate()
    {
        if (_canMove == true)
        {
            _rb.velocity = playerInput.leftStick.normalized * _moveSpeed;
        }
    }


    public void Dashing()
    {
        StartCoroutine(DashVersionTwo());
    }

    private IEnumerator DashVersionTwo()
    {
        
        Vector2 direction = playerInput.leftStick.normalized;
        _canMove = false;
        _currentDashTime = _startDashTime;
        while(_currentDashTime > 0f)
        {
            _currentDashTime -= Time.deltaTime;
            _rb.velocity = direction * _dashSpeed;
            yield return null;
        }
        _rb.velocity = Vector2.zero;
        _canMove = true;
    }
}
