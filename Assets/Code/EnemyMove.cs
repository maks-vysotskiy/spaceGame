using UnityEngine;
internal class EnemyMove : IMoveEnemy
{
    private Vector3 _direction;
    private readonly float _speed;


    public EnemyMove(float speed)
    {
        _speed = speed;
    }

    public void Move(Transform transform)
    {
        transform.Translate(Vector3.left * (_speed * Time.deltaTime));
    }


}

