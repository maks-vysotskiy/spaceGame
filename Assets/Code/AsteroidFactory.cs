using System;
using UnityEngine;
internal sealed class AsteroidFactory : IEnemyFactory
{
    public Enemy Create(Health hp)
    {
        var enemy = UnityEngine.Object.Instantiate(Resources.Load<Asteroid>("Asteroid"));
        enemy.DependencyInjectionHealth(hp);
        return enemy;
    }
}

