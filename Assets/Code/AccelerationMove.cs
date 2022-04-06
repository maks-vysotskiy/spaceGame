using UnityEngine;
internal sealed class AccelerationMove : MoveTransform
{
    private readonly float _acceleration;
    public AccelerationMove(Rigidbody2D rb, float speed,  Transform transform, float acceleration)
        : base(rb, speed, transform)
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

