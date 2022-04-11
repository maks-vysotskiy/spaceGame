using System;
using UnityEngine;
internal sealed class SpiderFactory : IEnemyFactory
{
    private const string _resourcesSpider = "Spider";
    public Enemy Create(Health hp)
    {
        var enemy = UnityEngine.Object.Instantiate(Resources.Load<Spider>(_resourcesSpider));
        enemy.DependencyInjectionHealth(hp);
        return enemy;
    }
}

