using System;
using UnityEngine;
using Object = UnityEngine.GameObject;
internal sealed class Ship : IMove, IRotation
{
    private readonly IMove _move;
    private readonly IRotation _rotation;
    private readonly ITakeDamageShip _takeDamage;
    private readonly IFireShip _fireShip1;
    private readonly IFireShip _fireShip2;

    public float Speed => _move.Speed;

    public Ship(IMove move, IRotation rotation, ITakeDamageShip takeDamage, IFireShip fireShip1, IFireShip fireShip2)
    {
        _move = move;
        _rotation = rotation;
        _takeDamage = takeDamage;
        _fireShip1 = fireShip1;
        _fireShip2 = fireShip2;
    }

    public float GetHp()
    {
        return _takeDamage.GetHp();
    }

    public void Move(float horizontal, float vertical, float deltatime)
    {
        _move.Move(horizontal, vertical, deltatime);
    }

    public void Braking()
    {
        _move.Braking();
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
        _fireShip1.Fire(isFire);
        _fireShip2.Fire(isFire);
    }
}

