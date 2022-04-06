using System;
using UnityEngine;
internal sealed class Ship : IMove, IRotation
{
    private readonly IMove _move;
    private readonly IRotation _rotation;
    public float Speed => _move.Speed;

    public Ship(IMove move, IRotation rotation)
    {
        _move = move;
        _rotation = rotation;
    }

    public void Move(float horizontal, float vertical, float deltatime)
    {
        _move.Move(horizontal, vertical, deltatime);
    }

    public void Rotation(Vector3 direction)
    {
        _rotation.Rotation(direction);
    }
    public void AddAcceleration()
    {
        if(_move is AccelerationMove accelerationMove)
        {
            accelerationMove.AddAcceleration();
        }
    }
    public void RemoveAcceleration()
    {
        if (_move is AccelerationMove accelerationMove)
        {
            accelerationMove.RemoveAcceleration();
        }
    }
}

