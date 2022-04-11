using UnityEngine;
internal class PhisicsMove : IMove
{
    private readonly Rigidbody2D _rigidBody;
    private Vector3 _move;
    private readonly Transform _transform;

    public float Speed { get; protected set; }

    public PhisicsMove(Rigidbody2D rigidBody, float speed, Transform transform)
    {
        _rigidBody = rigidBody;
        Speed = speed;
        _transform = transform;
    }

    public void Move(float horizontal, float vertical, float deltaTime)
    {
        var direction = new Vector3(horizontal, vertical, 0.0f);
        _rigidBody.AddForce(_transform.TransformDirection(direction));
    }
    public void Braking()
    {
        _rigidBody.velocity = Vector2.Lerp(_rigidBody.velocity, Vector2.zero, 0.02f);
    }

}

