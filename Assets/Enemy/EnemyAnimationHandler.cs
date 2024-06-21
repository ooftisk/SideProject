using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimationHandler : MonoBehaviour
{
    private Animator _animator;
    private NavMeshAgent _agent;
    private bool isMoving;
    private Vector3 previousDirection;
    [SerializeField] private float smoothnessFactor;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponentInParent<NavMeshAgent>();
        previousDirection = Vector3.zero;
    }

    private void Update()
    {
        Animate();
    }

    private void Animate()
    {
        if (_agent.velocity.magnitude > 0.1f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        _animator.SetBool("Moving", isMoving);

        if (isMoving)
        {
            Vector3 movementDirection = _agent.velocity.normalized;
            Vector3 smoothedDirection = Vector3.Lerp(previousDirection, movementDirection, Time.deltaTime * smoothnessFactor);
            _animator.SetFloat("X", smoothedDirection.x);
            _animator.SetFloat("Y", smoothedDirection.y);
            previousDirection = smoothedDirection;
        }
    }
}