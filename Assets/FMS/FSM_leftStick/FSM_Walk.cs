using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_Walk : FSMlStick
{
    protected readonly Vector2 _input;
    protected readonly float _speed;
    protected readonly Rigidbody2D _rb;
    protected readonly Animator _animator;

    public FSM_Walk(FSM fsm, Animator animator, Rigidbody2D rb, float speed) : base(fsm)
    {
        _speed = speed;
        _rb = rb;
        _animator = animator;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        var input = playerInput.leftStick.normalized;

        if (input.magnitude == 0f)
        {
            _fsm.SetStateLstick<FSM_Idle>();
        }

        Move(input);
        Animate(input);
    }

    protected virtual void Move(Vector2 input)
    {
        _rb.velocity = input * _speed;
    }

    protected virtual void Animate(Vector2 input)
    {
        bool moving;

        if (input.magnitude > 0.01f || input.magnitude < -0.01f)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        if (moving)
        {
            _animator.SetFloat("X", input.x);
            _animator.SetFloat("Y", input.y);
        }
        _animator.SetBool("Moving", moving);
    }
}
