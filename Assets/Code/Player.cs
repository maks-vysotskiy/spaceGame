using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _acceleration;
    [SerializeField] private float _hp;
    [SerializeField] private Rigidbody2D _bullet;
    [SerializeField] private Transform _gunPlace;
    [SerializeField] private float _force;

    private Camera _camera;
    private Rigidbody2D _player;
    private Ship _ship;

    private BulletPool _bulletPool;
    private int _bulletCounts = 50;

    private void Start()
    {
        _camera = Camera.main;
        _player = GetComponent<Rigidbody2D>();

        var moveTransform = new AccelerationMove(_player, _speed, transform, _acceleration);
        var rotation = new RotationShip(transform);
        var takeDamage = new TakeDamageShip(_hp);

        _ship = new Ship(moveTransform, rotation, takeDamage);
        _bulletPool = new BulletPool(_bulletCounts, "Laser", _gunPlace);
    }


    private void Update()
    {
        var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
        _ship.Rotation(direction);
        _ship.Move(Input.GetAxis(AxisManager.HORIZONTAL), Input.GetAxis(AxisManager.VERTICAL), Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _ship.AddAcceleration();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _ship.RemoveAcceleration();
        }

        if (Input.GetButtonDown(AxisManager.FIRE1))
        {
            var temAmmunition = _bulletPool.TakeBullet();
            temAmmunition.GetPool(_bulletPool);
            temAmmunition.gameObject.GetComponent<Rigidbody2D>().AddForce(_gunPlace.up * (_force * Time.deltaTime));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _ship.TakeDamage(collision.gameObject);
    }
}
