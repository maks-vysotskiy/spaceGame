using System;
using UnityEngine;
internal sealed class StateMoveLeft : IMoveState
{
    public void Enter()
    {
        Debug.Log("Turn left!");
    }

    public void Execute(Transform transform, float speed)
    {
        transform.Translate(Vector3.left * (speed * Time.deltaTime));
    }


    public void Exit()
    {
        Debug.Log("Stop turn left!");
    }
}

