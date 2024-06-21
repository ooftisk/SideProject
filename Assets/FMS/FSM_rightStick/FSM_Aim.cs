using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_Aim : FSMrStick
{
    protected readonly Transform _pivot;
    public FSM_Aim(FSM fsm, Transform transform) : base(fsm)
    {
        _pivot = transform;
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
        Debug.Log("Целюсь");

        var input = playerInput.rightStick.normalized;

        if (playerInput.rightStick.magnitude <= 0f)
        {
            _fsm.SetStateRstick<FSM_NoAim>();
        }

        Rotate(input);
    }

    protected virtual void Rotate(Vector2 input)
    {
        float angle = Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg;
        _pivot.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
