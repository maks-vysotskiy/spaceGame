using UnityEngine;
internal interface IBulletBuilder
{
    IBulletBuilder SetGunPlace(Transform gunPlace);
    IBulletBuilder SetForce(float force);
    LaserRed Build();
}

