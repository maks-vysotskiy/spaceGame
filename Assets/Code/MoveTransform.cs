using System;
using UnityEngine;
internal class MoveTransform: IMove
{
    private readonly Rigidbody2D _rb;
    private Vector3 _move;
    private readonly Transform _transform;
    public float Speed { get; protected set; }

    public MoveTransform(Rigidbody2D rb, float speed, Transform transform)
    {
        _rb = rb;
        Speed = speed;
        _transform = transform;
    }
        

    public void Move(float horizontal, float vertical, float deltaTime)
    {
        var direction = new Vector3(horizontal, vertical, 0.0f);
        _rb.AddForce(_transform.TransformDirection(direction));
                
    }
}

