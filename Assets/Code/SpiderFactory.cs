using System;
using UnityEngine;
internal sealed class SpiderFactory : IEnemyFactory
{
    public Enemy Create(Health hp)
    {
        var enemy = UnityEngine.Object.Instantiate(Resources.Load<Spider>("Spider"));
        enemy.DependencyInjectionHealth(hp);
        return enemy;
    }
}

