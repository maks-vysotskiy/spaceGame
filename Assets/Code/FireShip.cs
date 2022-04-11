using UnityEngine;
using Object = UnityEngine.GameObject;
internal class FireShip : IFireShip
{
    private readonly BulletPool _bulletPool;
    private readonly Transform _gunPlace;
    private readonly float _force;

    public FireShip(BulletPool bulletPool, Transform gunPlace, float force)
    {
        _bulletPool = bulletPool;
        _gunPlace = gunPlace;
        _force = force;
    }
    public void Fire(bool isFire)
    {
        if(isFire)
        {
            var bullet = _bulletPool.TakeBullet();
            var bulletRB = bullet.gameObject.GetComponent<Rigidbody2D>();
            bulletRB.AddForce(_gunPlace.up * (_force * Time.deltaTime));
        }
    }
}

