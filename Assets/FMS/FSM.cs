using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM
{
    private FSMlStick StateCurrentLstick { get; set; }
    private FSMrStick StateCurrentRstick { get; set; }

    private Dictionary<Type, FSMlStick> _statesLstick = new Dictionary<Type, FSMlStick>();

    private Dictionary<Type, FSMrStick> _statesRstick = new Dictionary<Type, FSMrStick>();


    public void AddStateRstick(FSMrStick state)
    {
        _statesRstick.Add(state.GetType(), state);
    }
    public void AddStateLstick(FSMlStick state)
    {
        _statesLstick.Add(state.GetType(), state);
    }

    public void SetStateLstick<T>() where T : FSMlStick
    {
        var type = typeof(T);

        if (StateCurrentLstick != null && StateCurrentLstick.GetType() == type)
        {
            return;
        }

        if (_statesLstick.TryGetValue(type, out var newState))
        {
            StateCurrentLstick?.Exit();
            StateCurrentLstick = newState;
            StateCurrentLstick.Enter();
        }
    }

    public void SetStateRstick<T>() where T : FSMrStick
    {
        var type = typeof(T);

        if (StateCurrentRstick != null && StateCurrentRstick.GetType() == type)
        {
            return;
        }

        if (_statesRstick.TryGetValue(type, out var newState))
        {
            StateCurrentRstick?.Exit();
            StateCurrentRstick = newState;
            StateCurrentRstick.Enter();
        }
    }

    public void Update()
    {
        StateCurrentLstick?.Update();
        StateCurrentRstick?.Update();
    }
}

