using System;
using UnityEngine;
using Object = UnityEngine.GameObject;
internal sealed class Ship : IMove, IRotation
{
    private readonly IMove _move;
    private readonly IRotation _rotation;
    private readonly ITakeDamageShip _takeDamage;
    private readonly IFireShip _fireShip;
    public float Speed => _move.Speed;

    public Ship(IMove move, IRotation rotation, ITakeDamageShip takeDamage, IFireShip fireShip)
    {
        _move = move;
        _rotation = rotation;
        _takeDamage = takeDamage;
        _fireShip = fireShip;
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

    public void TakeDamage(Object damageObject)
    {
        _takeDamage.TakeDamage(damageObject);
    }

    public void Fire(bool isFire)
    {
        _fireShip.Fire(isFire);
    }
}

