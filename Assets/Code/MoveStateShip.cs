using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
internal class MoveStateShip
{
    private readonly Transform _transform;
    private readonly float _speed;

    private Dictionary<Type, IMoveState> states;
    private IMoveState _stateCurrent;

    public MoveStateShip(Transform transform, float speed)
    {
        _transform = transform;
        _speed = speed;
        Start();
    }

    private void Start()
    {
        InitBehaviours();
        SetDefaultState();
    }

    private void InitBehaviours()
    {
        states = new Dictionary<Type, IMoveState>();

        states[typeof(StateMoveIdle)] = new StateMoveIdle();
        states[typeof(StateMoveForward)] = new StateMoveForward();
        states[typeof(StateMoveBack)] = new StateMoveBack();
        states[typeof(StateMoveRight)] = new StateMoveRight();
        states[typeof(StateMoveLeft)] = new StateMoveLeft();
    }
    private void SetState(IMoveState state)
    {
        if (_stateCurrent != null)
        {
            _stateCurrent.Exit();
        }

        _stateCurrent = state;
        _stateCurrent.Enter();

    }
    public void Execute()
    {
        _stateCurrent.Execute(_transform, _speed);
    }

    private void SetDefaultState()
    {
        SetIdleState();
    }

    private IMoveState GetState<T>() where T : IMoveState
    {
        var type = typeof(T);
        return states[type];
    }

    public void SetIdleState()
    {
        var state = GetState<StateMoveIdle>();
        SetState(state);
    }
    public void SetMoveRightState()
    {
        var state = GetState<StateMoveRight>();
        SetState(state);
    }
    public void SetMoveLeftState()
    {
        var state = GetState<StateMoveLeft>();
        SetState(state);
    }
    public void SetMoveForwardState()
    {
        var state = GetState<StateMoveForward>();
        SetState(state);
    }
    public void SetMoveBackState()
    {
        var state = GetState<StateMoveBack>();
        SetState(state);
    }

}

