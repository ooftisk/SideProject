using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KnockbackSystem : MonoBehaviour
{
    private Rigidbody2D _rb;
    private NavMeshAgent _agent;
    private float _knockForce;
    [SerializeField] private float _knockTime;
    private GameObject _player;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _agent = GetComponent<NavMeshAgent>();
    }

    public void KnockEffect(GameObject sender)
    {
        StopAllCoroutines();
        _rb.isKinematic = false;
        _rb.gravityScale = 0f;
        _agent.enabled = false;
        _player = GameObject.Find("Player");
        _knockForce = _player.GetComponentInChildren<WeaponShoot>().knockForce;
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        _rb.AddForce(direction * _knockForce, ForceMode2D.Impulse);
        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        _agent.enabled = true;
        _rb.isKinematic = true;
        yield return new WaitForSeconds(_knockTime);
        _rb.velocity = Vector3.zero;
    }
}
