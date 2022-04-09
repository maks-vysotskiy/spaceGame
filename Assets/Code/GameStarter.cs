using System;
using UnityEngine;
internal sealed class GameStarter : MonoBehaviour
{

    private void Start()
    {
        EnemyPool enemyPool = new EnemyPool(3);

        var enemy = enemyPool.GetEnemy("Asteroid");
        enemy.transform.position = Vector3.one;
        enemy.gameObject.SetActive(true);


        //Enemy.CreateAsteroidEnemy(new Health(100.0f, 100.0f));
        //Enemy.Factory.Create(new Health(100.0f, 100.0f));

        //IEnemyFactory factory = new AsteroidFactory();
        //factory.Create(new Health(100.0f, 100.0f));

        //var platform = new PlatformFactory().CreatePlatform(Application.platform);


    }
}

