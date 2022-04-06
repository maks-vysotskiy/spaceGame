using System;
using UnityEngine;
internal sealed class MoveTransform
{
    private readonly Transform _transform;
    private readonly float _speed;
    private Vector3 _move;

    public MoveTransform(Transform transform, float speed)
    {
        _transform = transform;
        _speed = speed;
    }

    public void Move(float horizontal, float vertical, float deltaTime)
    {
        var speed = _speed * deltaTime;
        _move.Set(horizontal * speed, vertical * speed, 0.0f);
        _transform.localPosition += _move;
    }
}

