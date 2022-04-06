using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _hp;
    [SerializeField] private Rigidbody2D _bullet;
    [SerializeField] private Transform _barrel;
    [SerializeField] private float _force;
    private Vector3 _move;

    private void Update()
    {
        var deltaTime = Time.deltaTime;
        var speed = _speed * deltaTime;
        _move.Set(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed, 0.0f);
        transform.localPosition += _move;

        if (Input.GetButtonDown("Fire1"))
        {
            var temAmmunition = Instantiate(_bullet, _barrel.position, _barrel.rotation);
            temAmmunition.AddForce(_barrel.up * _force * deltaTime);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(_hp<=0)
        {
            Destroy(gameObject);
        }
        else
        {
            _hp--;
        }
    }
}
