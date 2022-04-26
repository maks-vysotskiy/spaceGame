using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _acceleration;
    [SerializeField] private float _hp;
    [SerializeField] private Transform _gunPlace;
    [SerializeField] private Transform _gunPlaceLaserRed;
    [SerializeField] private float _force;

    public float HP
    {
        get
        {
            return _hp = _ship.GetHp();
        }
        
    }

    private Camera _camera;
    private Rigidbody2D _player;
    private Ship _ship;

    private BulletPool _bulletPool;
    private int _bulletCounts = 50;

    private void Start()
    {
        _camera = Camera.main;
        _player = GetComponent<Rigidbody2D>();

        _bulletPool = new BulletPool(_bulletCounts, "Laser", _gunPlace);

        var moveTransform = new AccelerationMove(_player, _speed, transform, _acceleration);
        var rotation = new RotationShip(transform);
        var takeDamage = new TakeDamageShip(this, _hp);
        var fire1 = new FireShip(_bulletPool, _gunPlace, _force, _gunPlaceLaserRed);
        var fire2 = new FireBlankShip("PIF-PAF, Mother fucker!!!!");

        _ship = new Ship(moveTransform, rotation, takeDamage, fire1, fire2);

    }


    private void Update()
    {
        var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);

        _ship.Rotation(direction);
        _ship.Move(Input.GetAxis(AxisManager.HORIZONTAL), Input.GetAxis(AxisManager.VERTICAL), Time.deltaTime);
        _ship.Fire(Input.GetButtonDown(AxisManager.FIRE1));

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _ship.AddAcceleration();
        }
        
        if (Input.GetAxis(AxisManager.HORIZONTAL) == 0 && Input.GetAxis(AxisManager.VERTICAL) == 0)
        {
            _ship.Braking();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _ship.RemoveAcceleration();
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _ship.TakeDamage(collision.gameObject);
    }


}
