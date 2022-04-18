using UnityEngine;
using Object = UnityEngine.Object;

internal sealed class BulletBuilder : IBulletBuilder
{
    private LaserRed _laserRed;

    public BulletBuilder() => _laserRed = new LaserRed();
    public LaserRed Build()
    {
        _laserRed = Resources.Load<LaserRed>("LaserRed");
        return _laserRed;


    }

    public IBulletBuilder SetForce(float force)
    {
        _laserRed.Force = force;
        return this;
    }

    public IBulletBuilder SetGunPlace(Transform gunPlace)
    {
        _laserRed.GunPlace = gunPlace;
        return this;
    }

}

