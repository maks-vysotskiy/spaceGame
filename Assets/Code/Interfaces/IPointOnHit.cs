using System;

public interface IPointOnHit
{
    event Action OnHitEnemy;
    void HitToEnemy();
}

