using System;
using UnityEngine;
internal sealed class GameStarter : MonoBehaviour
{
    private void Start()
    {
        Enemy.CreateAsteroidEnemy(new Health(100.0f, 100.0f));
        Enemy.Factory.Create(new Health(100.0f, 100.0f));

        IEnemyFactory factory = new AsteroidFactory();
        factory.Create(new Health(100.0f, 100.0f));
    }
}

