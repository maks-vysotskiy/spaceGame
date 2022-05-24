using System;
using UnityEngine;
internal sealed class StateMoveRight : IMoveState
{
    public void Enter()
    {
        Debug.Log("Turn right!");
    }

    public void Execute(Transform transform, float speed)
    {
        transform.Translate(Vector3.right * (speed * Time.deltaTime));
    }


    public void Exit()
    {
        Debug.Log("Stop turn right!");
    }
}

