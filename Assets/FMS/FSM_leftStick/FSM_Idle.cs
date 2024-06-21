using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_Idle : FSMlStick
{
    public FSM_Idle(FSM fsm) : base(fsm) { }

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
        Debug.Log("Да, я ничего не делаю");

        if (playerInput.leftStick.magnitude > 0.01f || playerInput.leftStick.magnitude < -0.01f)
        {
            _fsm.SetStateLstick<FSM_Walk>();
        }
    }
}
