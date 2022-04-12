using System;
using UnityEngine;
internal sealed class AsteroidFactory : IEnemyFactory
{
    private const string _resourcesAsteroid = "Asteroid";
    public Enemy Create(float hp)
    {
        var enemy = UnityEngine.Object.Instantiate(Resources.Load<Asteroid>(_resourcesAsteroid));
        enemy.DependencyInjectionHealth(hp);
        return enemy;
    }
}

