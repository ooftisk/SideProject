using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent _agent;
    [SerializeField] private GameObject _pivot;
    [SerializeField] private LayerMask _wallLayer;
    private EnemyTriggerHandler _trigger;

    public bool canShoot;



    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _trigger = GetComponentInChildren<EnemyTriggerHandler>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void Update()
    {
        PlayerDetect();
        ChasePlayer();
    }

    private void PlayerDetect()
    {
         Vector2 directionToPlayer = PlayerPositionTrack.PlayerPosition - _pivot.transform.position;

        float distance = directionToPlayer.magnitude;

        RaycastHit2D wallHit = Physics2D.Raycast(_pivot.transform.position, directionToPlayer, distance, _wallLayer);


        if (wallHit.collider == null & _trigger.PlayerDetected)
        { 
            canShoot = true;
        }
        else 
        {
            canShoot = false;
        }
    }

    private void ChasePlayer()
    {
        if(canShoot)
        {
            _agent.stoppingDistance = 2f;
        }
        else
        {
            if (_agent.enabled)
            {
                _agent.SetDestination(PlayerPositionTrack.PlayerPosition);
                _agent.stoppingDistance = 0f;
            }
        }
    }
}
