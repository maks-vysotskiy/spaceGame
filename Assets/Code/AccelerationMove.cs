using UnityEngine;
internal sealed class AccelerationMove : PhisicsMove
{
    private readonly float _acceleration;
    public AccelerationMove(Rigidbody2D rigidBody, float speed,  Transform transform, float acceleration)
        : base(rigidBody, speed, transform)
    {
        _acceleration = acceleration;
    }

    public void AddAcceleration()
    {
        Speed += _acceleration;
    }

    public void RemoveAcceleration()
    {
        Speed -= _acceleration;
    }
}

