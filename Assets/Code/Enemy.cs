using System;
using UnityEngine;
internal abstract class Enemy : MonoBehaviour
{
    public static IEnemyFactory Factory;
    public Health Health { get; private set; }
    public static Asteroid CreateAsteroidEnemy(Health hp)
    {
        var enemy = Instantiate(Resources.Load<Asteroid>("Asteroid"));
        enemy.Health = hp;
        return enemy;
    }
    public void DependencyInjectionHealth(Health hp)
    {
        Health = hp;
    }
}

