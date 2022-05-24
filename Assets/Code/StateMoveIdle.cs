using System;
using UnityEngine;
internal sealed class StateMoveIdle : IMoveState
{
    public void Enter()
    {
        Debug.Log("I do nothing!");
    }

    public void Execute(Transform transform, float speed)
    {
        Debug.Log("I'm in Idle state now");
    }

    public void Exit()
    {
        Debug.Log("Stop do nothing");
    }
}

