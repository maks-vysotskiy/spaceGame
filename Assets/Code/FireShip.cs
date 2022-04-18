using UnityEngine;
using Object = UnityEngine.GameObject;
internal class FireShip : IFireShip
{
    private readonly BulletPool _bulletPool;
    private readonly Transform _gunPlace;
    private readonly Transform _gunPlaceRedLaser;
    private readonly float _force;

    private readonly BulletBuilder _bulletBuilder;
    
    public FireShip(BulletPool bulletPool, Transform gunPlace, float force, Transform gunPlaceRedLaser)
    {
        _bulletPool = bulletPool;
        _gunPlace = gunPlace;
        _force = force;

        _bulletBuilder = new BulletBuilder();
        _gunPlaceRedLaser = gunPlaceRedLaser;


    }
    public void Fire(bool isFire)
    {
        if(isFire)
        {
            var bullet = _bulletPool.TakeBullet();
            var bulletRB = bullet.gameObject.GetComponent<Rigidbody2D>();
            bulletRB.AddForce(_gunPlace.up * (_force * Time.deltaTime));

            var laser = _bulletBuilder.SetForce(_force).SetGunPlace(_gunPlace);
            var laserRed = laser.Build();
            var LaserBullet = Object.Instantiate(laserRed, _gunPlaceRedLaser.position, _gunPlaceRedLaser.rotation);
            var LaserBulletRB = LaserBullet.GetComponent<Rigidbody2D>();
            LaserBulletRB.AddForce(_gunPlace.up * (_force * Time.deltaTime));
        }
    }
}

