using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMrStick
{
    protected readonly FSM _fsm;

    public FSMrStick(FSM fsm)
    {
        _fsm = fsm;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
}

