using System;
using UnityEngine;
internal sealed class StateMoveForward : IMoveState
{
    public void Enter()
    {
        Debug.Log("Go forward!");
    }

    public void Execute(Transform transform, float speed)
    {
        transform.Translate(Vector3.up * (speed * Time.deltaTime));
    }

    public void Exit()
    {
        Debug.Log("Stop go forward");
    }
}

