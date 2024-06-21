using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFMS : MonoBehaviour
{
    private FSM _fsm;
    private Rigidbody2D _rb;
    private Animator _animator;
    [SerializeField] private float _walkSpeed;
    [SerializeField] private Transform _pivot;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _fsm = new FSM();
        _fsm.AddStateLstick(new FSM_Idle(_fsm));
        _fsm.AddStateLstick(new FSM_Walk(_fsm, _animator, _rb, _walkSpeed));
        _fsm.AddStateRstick(new FSM_NoAim(_fsm));
        _fsm.AddStateRstick(new FSM_Aim(_fsm, _pivot));

        _fsm.SetStateLstick<FSM_Idle>();
        _fsm.SetStateRstick<FSM_NoAim>();
    }

    private void Update()
    {
        _fsm.Update();
    }
}
