using UnityEngine;
public interface IMoveState
{
    void Enter();
    void Exit();
    void Execute(Transform transform, float speed);
}

