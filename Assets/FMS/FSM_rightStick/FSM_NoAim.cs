using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_NoAim : FSMrStick
{
    public FSM_NoAim(FSM fsm) : base(fsm) { }

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
        Debug.Log("Не целюсь");
        if (playerInput.rightStick.magnitude > 0f)
        {
            _fsm.SetStateRstick<FSM_Aim>();
        }
    }
}
